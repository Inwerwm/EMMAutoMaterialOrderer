using MikuMikuMethods.MME;
using MikuMikuMethods.Pmx;
using System;
using System.IO;
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
                model.WriteEMM();
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
        EMMData emm;
        /// <summary>
        /// 基準のPMX
        /// </summary>
        PmxModelData basisPmx;
        /// <summary>
        /// 並び順変更後のPMX
        /// </summary>
        PmxModelData targetPmx;
        string filePath;

        public Model()
        {
            emm = new EMMData();
            basisPmx = new PmxModelData();
            targetPmx = new PmxModelData();
        }

        public void ReadEMM(string path)
        {
            using (var reader = new StreamReader(path, Encoding.GetEncoding("shift_jis")))
            {
                emm.Read(reader);
                filePath = path;
            }
        }

        public void WriteEMM()
        {
            if (filePath == null)
                throw new ArgumentNullException("EMMファイルが読み込まれていないうちに出力を試みました");

            filePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_writed.emm";
            using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("shift_jis")))
            {
                emm.Write(writer);
            }
            MessageBox.Show(filePath + "に出力しました");
        }

        public void ReadBasisPmx(string path)
        {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.GetEncoding("shift_jis")))
            {
                basisPmx.Read(reader);
            }
        }

        public void ReadTargetPmx(string path)
        {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.GetEncoding("shift_jis")))
            {
                targetPmx.Read(reader);
            }
        }
    }
}
