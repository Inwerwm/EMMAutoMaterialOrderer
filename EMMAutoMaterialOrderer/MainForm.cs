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
                    listBoxOrderObj.Items.AddRange(model.Emm.Effects[model.Emm.Effects.Select(o => o.Name).ToList().IndexOf("Object")].ObjectSettings.Select(s => Path.GetFileName(s.EffectSetting.Path)).ToArray());
                }
            }
            catch (Exception ex)
            {
                throw;
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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

            OrderEMM(objID);

            filePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_writed.emm";
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
