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
                var tabName = str.Split('@')[1];
                tabName.Replace("]\r\n", "");
                // 内容
                Effects.Add(new EMMEffectType(tabName, reader));
            }
        }

        /// <param name="writer">エンコードはシフトJISに設定すること</param>
        public void Write(StreamWriter writer)
        {
            if (writer.Encoding != Encoding.GetEncoding("shift_jis"))
                throw new ArgumentException("EMMData Write エンコードエラー" + Environment.NewLine + "StreamWriterのエンコードをシフトJISに設定してください");
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
                if (line == "\r\n")
                    break;
                // {[0]：Typ?, [1]：=, [2]：Value}
                str = line.Split(' ');
                //値クラスタから改行文字を削除
                str[2] = str[2].Replace("\r\n", "");

                // 種類クラスタの最初の文字で種類を判断
                if (str[0][0] == 'D' || str[0][0] == 'O')
                    Owner = str[2];
                else if (str[0].Contains("["))
                {
                    //サブセット
                    //str[0]を種類IDとサブセット添字に分割
                    //{[0]：ObjID, [1]：SubID}
                    var numji = str[0].Split('[');
                    int objID = int.Parse(Regex.Replace(numji[0], @"[^0-9]", ""));
                    int subID = int.Parse(Regex.Replace(numji[1], @"[^0-9]", ""));

                    while (ObjectSettings[objID].SubsetSettings.Count <= subID)
                    {
                        ObjectSettings[objID].SubsetSettings.Add(new EMMEffectSetting());
                    }

                    // 種類クラスタが"."を含むならShow設定
                    if (str[0].Contains("."))
                        ObjectSettings[objID].SubsetSettings[subID].Show = bool.Parse(str[2]);
                    else
                        ObjectSettings[objID].SubsetSettings[subID].Path = str[2];
                }
                else
                {
                    //オブジェクト
                    var i = int.Parse(Regex.Replace(str[0], @"[^0-9]", ""));
                    while (ObjectSettings.Count <= i)
                    {
                        ObjectSettings.Add(new EMMObjectSettings());
                    }

                    if (str[0].Contains("."))
                    {
                        // 種類クラスタが"."を含むならShow設定
                        ObjectSettings[i].IsModel = str[0][0] == 'P';
                        ObjectSettings[i].EffectSetting.Show = bool.Parse(str[2]);
                    }
                    else
                    {
                        ObjectSettings[i].IsModel = str[0][0] == 'P';
                        ObjectSettings[i].EffectSetting.Path = str[2];
                    }
                }
            }
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
