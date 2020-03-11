using MikuMikuEffect;
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
    }

    public class Model
    {
        EMMData emm;
        string filePath;

        public Model()
        {
            emm = new EMMData();
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
    }
}
