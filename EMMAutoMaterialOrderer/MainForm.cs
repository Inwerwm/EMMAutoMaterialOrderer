using MikuMikuMethods;
using MikuMikuMethods.MME;
using MikuMikuMethods.Pmx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMAutoMaterialOrderer
{
    public partial class MainForm : Form
    {
        Model model;

        public MainForm()
        {
            InitializeComponent();
            model = new Model();
        }

        private void buttonReadEMM_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "EMMファイル(*.emm)|*.emm|すべてのファイル(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    model.ReadEMM(ofd.FileName);
                    textBoxReadEMM.Text = ofd.FileName;
                    listBoxOrderObj.Items.Clear();
                    listBoxOrderObj.Items.AddRange(model.Emm.Effects.Find(eft => eft.Name == "Object").ObjectSettings.Select(s => Path.GetFileName(s.EffectSetting.Path)).ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonWriteEMM_Click(object sender, EventArgs e)
        {
            try
            {
                model.WriteEMM(listBoxOrderObj.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReadBasisPmx_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PMXファイル(*.pmx)|*.pmx|すべてのファイル(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    model.ReadBasisPmx(ofd.FileName);
                    textBoxReadBasisPmx.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void buttonReadTargetPMX_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PMXファイル(*.pmx)|*.pmx|すべてのファイル(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    model.ReadTargetPmx(ofd.FileName);
                    textBoxReadTargetPMX.Text = ofd.FileName;

                    listBoxOrderObj.SelectedItem = Path.GetFileName(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void Common_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private static string GetDragFilePath(DragEventArgs e, string extention)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                throw new ArgumentException("ファイルをドロップしてください。");
            }

            var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!filenames.Length.IsWithin(1, 1))
            {
                throw new RankException("ファイルは1つだけドロップしてください。");
            }

            var fullPath = filenames[0];

            if (string.Compare(Path.GetExtension(fullPath).Trim('.'), extention, true) != 0)
            {
                throw new FormatException($"拡張子が違います。{Environment.NewLine}{extention.ToUpper()}ファイルをドロップしてください。");
            }

            return fullPath;
        }

        private void ReadEMM_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string path = GetDragFilePath(e, "EMM");
                model.ReadEMM(path);
                textBoxReadEMM.Text = path;
                listBoxOrderObj.Items.Clear();
                listBoxOrderObj.Items.AddRange(model.Emm.Effects[model.Emm.Effects.Select(o => o.Name).ToList().IndexOf("Object")].ObjectSettings.Select(s => Path.GetFileName(s.EffectSetting.Path)).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadBasisPmx_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string path = GetDragFilePath(e, "PMX");
                model.ReadBasisPmx(path);
                textBoxReadBasisPmx.Text = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadTargetPMX_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string path = GetDragFilePath(e, "PMX");
                model.ReadTargetPmx(path);
                textBoxReadTargetPMX.Text = path;

                listBoxOrderObj.SelectedItem = Path.GetFileName(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Model
    {
        bool readBasis;
        bool readTarget;
        string filePath;

        /// <summary>
        /// 基準のPMX
        /// </summary>
        public PmxModelData BasisPmx { get; private set; }

        /// <summary>
        /// 並び順変更後のPMX
        /// </summary>
        public PmxModelData TargetPmx { get; private set; }
        public EMMData Emm { get; private set; }

        public Model()
        {
            Emm = new EMMData();
            BasisPmx = new PmxModelData();
            readBasis = false;
            TargetPmx = new PmxModelData();
            readTarget = false;
        }

        public void ReadEMM(string path)
        {
            using (var reader = new StreamReader(path, Encoding.GetEncoding("shift_jis")))
            {
                Emm.Read(reader);
                filePath = path;
            }
        }

        public void WriteEMM(int objID)
        {
            if (filePath == null)
                throw new ArgumentException("EMMファイルが読み込まれていないうちに出力を試みました");

            if (objID < 0)
                throw new ArgumentException("リストボックスから並び替え対象オブジェクトを選択してください");

            var backupName = $"{Path.GetDirectoryName(filePath)}\\{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.emm";
            using (var writer = new StreamWriter(backupName, false, Encoding.GetEncoding("shift_jis")))
            {
                Emm.Write(writer);
            }

            OrderEMM(objID);

            using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("shift_jis")))
            {
                Emm.Write(writer);
            }
            MessageBox.Show(filePath + "に出力しました");
        }

        public void ReadBasisPmx(string path)
        {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.GetEncoding("shift_jis")))
            {
                BasisPmx.Read(reader);
                readBasis = true;
            }
        }

        public void ReadTargetPmx(string path)
        {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.GetEncoding("shift_jis")))
            {
                TargetPmx.Read(reader);
                readTarget = true;
            }
        }

        public void OrderEMM(int objID)
        {
            if (!(readBasis && readTarget))
                throw new ArgumentException("少なくとも一方のPMXファイルが読み込まれていないうちに出力を試みました");

            var basisMaterial = BasisPmx.MaterialArray.Select(m => m.MaterialName).ToList();
            var targetMaterial = TargetPmx.MaterialArray.Select(m => m.MaterialName).ToList();

            //basis => target の材質名ID写像を生成
            var mapBtoT = new List<int>();
            foreach (var mat in basisMaterial)
            {
                mapBtoT.Add(targetMaterial.IndexOf(mat));
            }

            int objTabID = Emm.Effects.Select(o => o.Name).ToList().IndexOf("Object");
            for (int i = 0; i < Emm.Effects.Count; i++)
            {
                if (i == objTabID)
                    continue;

                Emm.Effects[i].ObjectSettings[objID].SubsetSettings = MikuMikuMethods.Utilities.Order.ByMap(mapBtoT, Emm.Effects[i].ObjectSettings[objID].SubsetSettings);
            }
        }
    }
}
