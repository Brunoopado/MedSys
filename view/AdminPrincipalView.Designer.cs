namespace MedSys.view
{
    partial class AdminPrincipalView
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
            this.cbbEntidade = new System.Windows.Forms.ComboBox();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTeste = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbbEntidade
            // 
            this.cbbEntidade.FormattingEnabled = true;
            this.cbbEntidade.Items.AddRange(new object[] {
            "Médicos",
            "Pacientes",
            "Usuários",
            "Consultas"});
            this.cbbEntidade.Location = new System.Drawing.Point(57, 12);
            this.cbbEntidade.Name = "cbbEntidade";
            this.cbbEntidade.Size = new System.Drawing.Size(121, 21);
            this.cbbEntidade.TabIndex = 0;
            this.cbbEntidade.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.AutoSize = true;
            this.pnlFiltro.Location = new System.Drawing.Point(1, 39);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(250, 374);
            this.pnlFiltro.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Location = new System.Drawing.Point(310, 39);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(35, 13);
            this.lblTeste.TabIndex = 3;
            this.lblTeste.Text = "label1";
            // 
            // AdminPrincipalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTeste);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.cbbEntidade);
            this.Name = "AdminPrincipalView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbEntidade;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTeste;
    }
}