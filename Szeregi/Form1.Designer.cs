namespace Szeregi
{
    partial class KokpitProjektuNr2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSzeregLaboratoryjny = new System.Windows.Forms.Button();
            this.btnSzeregProjektowy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSzeregLaboratoryjny
            // 
            this.btnSzeregLaboratoryjny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSzeregLaboratoryjny.Location = new System.Drawing.Point(80, 162);
            this.btnSzeregLaboratoryjny.Name = "btnSzeregLaboratoryjny";
            this.btnSzeregLaboratoryjny.Size = new System.Drawing.Size(276, 73);
            this.btnSzeregLaboratoryjny.TabIndex = 0;
            this.btnSzeregLaboratoryjny.Text = "Analizator laboratoryjnego szeregu potegowego";
            this.btnSzeregLaboratoryjny.UseVisualStyleBackColor = true;
            this.btnSzeregLaboratoryjny.Click += new System.EventHandler(this.btnSzeregLaboratoryjny_Click);
            // 
            // btnSzeregProjektowy
            // 
            this.btnSzeregProjektowy.Location = new System.Drawing.Point(400, 162);
            this.btnSzeregProjektowy.Name = "btnSzeregProjektowy";
            this.btnSzeregProjektowy.Size = new System.Drawing.Size(293, 73);
            this.btnSzeregProjektowy.TabIndex = 1;
            this.btnSzeregProjektowy.Text = "Analizator indywidualnego szeregu potegowego";
            this.btnSzeregProjektowy.UseVisualStyleBackColor = true;
            // 
            // KokpitProjektuNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSzeregProjektowy);
            this.Controls.Add(this.btnSzeregLaboratoryjny);
            this.Name = "KokpitProjektuNr2";
            this.Text = "Kokpit projektu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KokpitProjektuNr2_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSzeregLaboratoryjny;
        private System.Windows.Forms.Button btnSzeregProjektowy;
    }
}

