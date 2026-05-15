namespace WinApp
{
    partial class Principal
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.frmVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.frmVisualizacionVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.frmPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmVentas,
            this.frmVisualizacionVentas,
            this.frmPerfil});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1054, 38);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // frmVentas
            // 
            this.frmVentas.Name = "frmVentas";
            this.frmVentas.Size = new System.Drawing.Size(169, 34);
            this.frmVentas.Text = "Gestión Ventas";
            // 
            // frmVisualizacionVentas
            // 
            this.frmVisualizacionVentas.Name = "frmVisualizacionVentas";
            this.frmVisualizacionVentas.Size = new System.Drawing.Size(129, 34);
            this.frmVisualizacionVentas.Text = "Ver Ventas";
            // 
            // frmPerfil
            // 
            this.frmPerfil.Name = "frmPerfil";
            this.frmPerfil.Size = new System.Drawing.Size(77, 34);
            this.frmPerfil.Text = "Perfil";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 645);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem frmVentas;
        private System.Windows.Forms.ToolStripMenuItem frmVisualizacionVentas;
        private System.Windows.Forms.ToolStripMenuItem frmPerfil;
    }
}