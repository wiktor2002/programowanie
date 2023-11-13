using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szeregi
{
    public partial class KokpitProjektuNr2 : Form
    {
        public KokpitProjektuNr2()
        {
            InitializeComponent();
        }

        private void btnSzeregLaboratoryjny_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "SzeregLaboratoryjny")
                {
                    Formularz.Show();
                    this.Hide();
                    return;
                }
            }
            SzeregLaboratoryjny AnalizatorSzeregu = new SzeregLaboratoryjny();
            AnalizatorSzeregu.Show();
            this.Hide();
        }

        private void KokpitProjektuNr2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz " +
                "zamknac formularz glowny i zakonczyc dzialanie programu?",
                this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
