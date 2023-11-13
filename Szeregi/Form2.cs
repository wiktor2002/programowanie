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
    public partial class SzeregLaboratoryjny : Form
    {
        const float DolnaGranicaX = float.MinValue;
        const float GornaGranicaX = float.MaxValue;

        float[,] TWS;
        public SzeregLaboratoryjny()
        {
            InitializeComponent();
        }

        private void SzeregLaboratoryjny_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz " +
                "zamknac ten formularz i przejsc do formularza glownego?", this.Text,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);

            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;

                foreach (Form Formularz in Application.OpenForms)
                {
                    if (Formularz.Name == "KokpitProjektuNr2")
                    {
                        this.Hide();
                        Formularz.Show();
                        return;
                    }
                }
                KokpitProjektuNr2 FormKokpitProjektuNr2 = new KokpitProjektuNr2();
                FormKokpitProjektuNr2.Show();
                this.Hide();
            
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz " +
                "zamknac ten formularz i przejsc do formularza glownego?", this.Text,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);

            if (OknoMessage == DialogResult.Yes)
            {
                //e.Cancel = false;

                foreach (Form Formularz in Application.OpenForms)
                {
                    if (Formularz.Name == "KokpitProjektuNr2")
                    {
                        this.Hide();
                        Formularz.Show();
                        return;
                    }
                }
                KokpitProjektuNr2 FormKokpitProjektuNr2 = new KokpitProjektuNr2();
                FormKokpitProjektuNr2.Show();
                this.Hide();

            }
            else
            {
                //e.Cancel = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnWartoscSzeregu_Click(object sender, EventArgs e)
        {
            short k;
            float X = float.Parse(txtX.Text);
            float Eps = float.Parse(txtEps.Text);
            txtS.Text = Convert.ToString(SumaSzereguPotegowego(X, Eps, out k));
            txtK.Text = Convert.ToString(k);
        }

        float SumaSzereguPotegowego(float X, float Eps, out short k)
        {
            k = 0;
            float w = 1.0F;
            float S = w;
            while (Math.Abs(w)>Eps)
            {
                k++;
                w = w * (-1) * X / k;
                S = S + w;
            }

            return S;
        }

        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            float Xd, Xg, h, Eps;
            if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
                return;
            if (TWS is null) TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            WypisanieWynikowDoKontrolkiDataGridView(TWS, dgvTWS);
        }

        bool PobranieDanych_Xd_Xg_h_Eps(out float Xd, out float Xg, out float h, out float Eps)
        {
            Xd = Xg = h = Eps = 0.0F;
            if (!float.TryParse(txtXd.Text, out Xd))
            {
                errorProvider1.SetError(txtXd, "ERROR: w zapisie Xd wystapil niedozwolony znak");
                return false;
            }
            if ((Xd < DolnaGranicaX) || (Xd > GornaGranicaX))
            {
                errorProvider1.SetError(txtXd, "ERROR: podane Xd nie miesci sie w przedziale zbieznosci szeregu");
                return false;
            }
            if (!float.TryParse(txtXg.Text, out Xg))
            {
                errorProvider1.SetError(txtXg, "ERROR: w zapisie Xg wystapil niedozwolony znak");
                return false;
            }
            if ((Xg < DolnaGranicaX) || (Xg > GornaGranicaX))
            {
                errorProvider1.SetError(txtXg, "ERROR: podane Xg nie miesci sie w przedziale zbieznosci szeregu");
                return false;
            }
            if (Xd > Xg)
            {
                errorProvider1.SetError(txtXg, "ERROR: granice przedzialu podane w odwrotnej kolejnosci");
                return false;
            }
            txtXg.Enabled = false; 
            txtXd.Enabled = false;  
            if (!float.TryParse(txtH.Text, out h))
            {
                errorProvider1.SetError(txtH, "ERROR: w zapisie przyrostu h wystapil niedozwolony znak");
                return false;
            }
            if ((h <= 0.0F) || (h > (Xg-Xd)))
            {
                errorProvider1.SetError(txtH, "ERROR: podana wartosc h jest niewlasciwa");
                return false;
            }
            if (!float.TryParse(txtEps.Text, out Eps))
            {
                errorProvider1.SetError(txtEps, "ERROR: w zapisie Eps wystapil niedozwolony znak");
                return false;
            }
            if ((Eps <= 0.0F) || (Eps >= 1.0F))
            {
                errorProvider1.SetError(txtEps, "ERROR: podana wartosc Eps jest niewlasciwa");
                return false;
            }

            return true;
        }

        void TablicowanieWartosciSzeregu(float Xd, float Xg, float h, float Eps, out float[,] TWS)
        {
            int n = (int)((Xg- Xd) / h + 1);
            TWS = new float[n, 3];
            float X;
            int i;
            short LicznikZsumowanychWyrazow;
            for (X = Xd, i = 0; i < TWS.GetLength(0); i++, X = Xd + i * h)
            {
                TWS[i, 0] = X;
                TWS[i, 1] = SumaSzereguPotegowego(X, Eps, out LicznikZsumowanychWyrazow);
                TWS[i, 2] = LicznikZsumowanychWyrazow;
            }
        }

        void WypisanieWynikowDoKontrolkiDataGridView(float[,] TWS, DataGridView dgvTWS)
        {
            dgvTWS.Rows.Clear();
            for (int i = 0; i<= TWS.GetLength(0); i++)
            {
                dgvTWS.Rows.Add();
                dgvTWS.Rows[i].Cells[0].Value = string.Format("{0:0.00}", TWS[i, 0]);
                dgvTWS.Rows[i].Cells[1].Value = string.Format("{0:0.0000}", TWS[i, 1]);
                dgvTWS.Rows[i].Cells[2].Value = string.Format("{0}", TWS[i, 2]);
            }
        }
    }
}
