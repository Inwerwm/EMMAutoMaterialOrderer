using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MikuMikuEffect
{
    public class EMMData
    {
        public int Version { get; private set; }
        public List<EMMEffectType> Effects { get; set; }

        public EMMData()
        {
            Version = 3;
            Effects = new List<EMMEffectType>();
        }

        public EMMData(StreamReader reader)
        {
            Effects = new List<EMMEffectType>();
            Read(reader);
        }

        /// <param name="reader">エンコードはシフトJISに設定すること</param>
        public void Read(StreamReader reader)
        {
            if (reader.CurrentEncoding != Encoding.GetEncoding("shift_jis"))
                throw new ArgumentException("EMMData Read エンコードエラー" + Environment.NewLine + "StreamReaderのエンコードをシフトJISに設定してください");

            if (reader.ReadLine() != "[Info]")
                throw new FormatException("読み込まれたファイル形式がEMMファイルと違います");

            string str;

            // Version
            str = reader.ReadLine();
            // strから数値のみ抽出してVersionに代入
            Version = int.Parse(Regex.Replace(str, @"[^0-9]", ""));
            //改行
            reader.ReadLine();

            // [Object]
            reader.ReadLine();
            // 内容
            Effects.Add(new EMMEffectType("Object", reader));

            // [Effect]
            reader.ReadLine();
            // 内容
            Effects.Add(new EMMEffectType("", reader));

            while ((str = reader.ReadLine()) != null)
            {
                // [Effect@tabName]
                var tabName = str.Split('@')[1].Replace("]", "");
                // 内容
                Effects.Add(new EMMEffectType(tabName, reader));
            }

            // IsModelの整合性を確保
            for (int i = 1; i < Effects.Count; i++)
            {
                for (int j = 0; j < Effects[i].ObjectSettings.Count; j++)
                {
                    Effects[i].ObjectSettings[j].IsModel = Effects[0].ObjectSettings[j].IsModel;
                }
            }
        }

        /// <param name="writer">エンコードはシフトJISに設定すること</param>
        public void Write(StreamWriter writer)
        {
            if (writer.Encoding != Encoding.GetEncoding("shift_jis"))
                throw new ArgumentException("EMMData Write エンコードエラー" + Environment.NewLine + "StreamWriterのエンコードをシフトJISに設定してください");

            writer.WriteLine("[Info]");
            writer.WriteLine(GetValueString("Version", Version.ToString()));
            writer.WriteLine("");

            foreach (var item in Effects)
            {
                item.Write(writer);
                writer.WriteLine("");
            }
        }

        private string GetValueString(string name, string value)
        {
            return name + " = " + value;
        }
    }

    public class EMMEffectType
    {
        /// <summary>
        /// "" => [Effect], "Object" => [Object], "???" => [Effect@???]
        /// </summary>
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Count { get { return ObjectSettings.Count; } }
        public List<EMMObjectSettings> ObjectSettings { get; set; }

        /// <param name="name">"" => [Effect], "Object" => [Object], "???" => [Effect@???]</param>
        public EMMEffectType(string name = "", string owner = "none")
        {
            Name = name;
            Owner = owner;
            ObjectSettings = new List<EMMObjectSettings>();
        }

        /// <param name="name">"" => [Effect], "Object" => [Object], "???" => [Effect@???]</param>
        public EMMEffectType(string name, StreamReader reader)
        {
            Name = name;
            ObjectSettings = new List<EMMObjectSettings>();
            Read(reader);
        }

        public void Read(StreamReader reader)
        {
            if (reader.CurrentEncoding != Encoding.GetEncoding("shift_jis"))
                throw new ArgumentException("EMMData Read エンコードエラー" + Environment.NewLine + "StreamReaderのエンコードをシフトJISに設定してください");

            string[] str;

            while (true)
            {
                var line = reader.ReadLine();
                //読み込んだ行が改行文字のみであった場合ループから抜ける
                if (line == "")
                    break;
                // {[0]：Typ?, [1]：Value}
                str = line.Split('=');
                //値クラスタ最初の空白文字を削除
                str[1] = str[1].Remove(0, 1);

                // 種類クラスタの最初の文字で種類を判断
                if (str[0][0] == 'D' || str[0][0] == 'O')
                    Owner = str[1];
                else if (str[0].Contains("["))
                {
                    //サブセット
                    //str[0]を種類IDとサブセット添字に分割
                    //{[0]：ObjID, [1]：SubID}
                    var numji = str[0].Split('[');
                    int objID = int.Parse(Regex.Replace(numji[0], @"[^0-9]", "")) - 1;
                    int subID = int.Parse(Regex.Replace(numji[1], @"[^0-9]", ""));

                    while (ObjectSettings[objID].SubsetSettings.Count <= subID)
                    {
                        ObjectSettings[objID].SubsetSettings.Add(new EMMEffectSetting());
                    }

                    // 種類クラスタが"."を含むならShow設定
                    if (str[0].Contains("."))
                        ObjectSettings[objID].SubsetSettings[subID].Show = bool.Parse(str[1]);
                    else
                        ObjectSettings[objID].SubsetSettings[subID].Path = str[1];
                }
                else
                {
                    //オブジェクト
                    var i = int.Parse(Regex.Replace(str[0], @"[^0-9]", "")) - 1;
                    while (ObjectSettings.Count <= i)
                    {
                        ObjectSettings.Add(new EMMObjectSettings());
                    }

                    if (str[0].Contains("."))
                    {
                        // 種類クラスタが"."を含むならShow設定
                        ObjectSettings[i].IsModel = str[0][0] == 'P';
                        ObjectSettings[i].EffectSetting.Show = bool.Parse(str[1]);
                    }
                    else
                    {
                        ObjectSettings[i].IsModel = str[0][0] == 'P';
                        ObjectSettings[i].EffectSetting.Path = str[1];
                    }
                }
            }
        }

        public void Write(StreamWriter writer)
        {
            string tabName = Name == "" ? "Effect"
                           : Name == "Object" ? "Object"
                           : "Effect@" + Name;
            writer.WriteLine("[" + tabName + "]");

            if (Name != "Object")
            {
                if (Name == "")
                    writer.WriteLine(GetValueString("Default", Owner));
                else
                    writer.WriteLine(GetValueString("Owner", Owner));
            }

            for (int i = 0; i < Count; i++)
            {
                var left = ObjectSettings[i].IsModel ? "Pmd" : "Acs";
                left += i + 1;
                writer.WriteLine(GetValueString(left, ObjectSettings[i].EffectSetting.Path));
                if (Name != "Object")
                {
                    if (!ObjectSettings[i].EffectSetting.Show)
                        writer.WriteLine(GetValueString(left + ".show", ObjectSettings[i].EffectSetting.Show));

                    if (ObjectSettings[i].SubsetSettings.Count > 0)
                    {
                        for (int j = 0; j < ObjectSettings[i].SubsetSettings.Count; j++)
                        {
                            if (ObjectSettings[i].SubsetSettings[j].Path != "none")
                                writer.WriteLine(GetValueString(left + "[" + j + "]", ObjectSettings[i].SubsetSettings[j].Path));
                            if (!ObjectSettings[i].SubsetSettings[j].Show)
                                writer.WriteLine(GetValueString(left + "[" + j + "].show", ObjectSettings[i].SubsetSettings[j].Show));
                        }
                    }
                }
            }
        }

        private string GetValueString(string name, string value)
        {
            return name + " = " + value;
        }

        private string GetValueString(string name, bool value)
        {
            return GetValueString(name, value.ToString().ToLower());
        }
    }

    public class EMMObjectSettings
    {
        public bool IsModel { get; set; }
        public EMMEffectSetting EffectSetting { get; set; }
        public int Count { get { return SubsetSettings.Count; } }
        public List<EMMEffectSetting> SubsetSettings { get; set; }

        public EMMObjectSettings(bool isModel = true, string path = "none", bool show = true)
        {
            IsModel = isModel;
            EffectSetting = new EMMEffectSetting(path, show);
            SubsetSettings = new List<EMMEffectSetting>();
        }
    }

    public class EMMEffectSetting
    {
        public bool Show { get; set; }
        public string Path { get; set; }

        public EMMEffectSetting(string path = "none", bool show = true)
        {
            Show = show;
            Path = path;
        }
    }
}
