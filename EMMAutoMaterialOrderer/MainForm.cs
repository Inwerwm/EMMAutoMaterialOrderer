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

        private void buttonOpenEMM_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "EMMファイル(*.emm)|*.emm|すべてのファイル(*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    model.OpenEMM(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }

    public class Model
    {
        EMMData emm;

        public Model()
        {
            emm = new EMMData();
        }

        public void OpenEMM(string path)
        {
            using (var reader = new StreamReader(path, Encoding.GetEncoding("shift_jis")))
            {
                emm.Read(reader);
            }
        }
    }
}
