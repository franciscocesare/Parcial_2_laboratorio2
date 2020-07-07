namespace Cesare.Francisco._2D
{
    partial class FrmEvaluados
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaluados));
            this.listBoxRecreo = new System.Windows.Forms.ListBox();
            this.DuracionRecreo = new System.Windows.Forms.Timer(this.components);
            this.lblRecreo = new System.Windows.Forms.Label();
            this.lblTiempoRecreo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxRecreo
            // 
            this.listBoxRecreo.FormattingEnabled = true;
            this.listBoxRecreo.Location = new System.Drawing.Point(12, 38);
            this.listBoxRecreo.Name = "listBoxRecreo";
            this.listBoxRecreo.Size = new System.Drawing.Size(128, 290);
            this.listBoxRecreo.TabIndex = 0;
            // 
            // DuracionRecreo
            // 
            this.DuracionRecreo.Interval = 1000;
            this.DuracionRecreo.Tick += new System.EventHandler(this.DuracionRecreo_Tick);
            // 
            // lblRecreo
            // 
            this.lblRecreo.Font = new System.Drawing.Font("Stencil", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecreo.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRecreo.Location = new System.Drawing.Point(-3, 3);
            this.lblRecreo.Name = "lblRecreo";
            this.lblRecreo.Size = new System.Drawing.Size(617, 32);
            this.lblRecreo.TabIndex = 1;
            this.lblRecreo.Text = "Tenemos 5\" de Recreo los Evaluados";
            // 
            // lblTiempoRecreo
            // 
            this.lblTiempoRecreo.AutoSize = true;
            this.lblTiempoRecreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoRecreo.Location = new System.Drawing.Point(165, 64);
            this.lblTiempoRecreo.Name = "lblTiempoRecreo";
            this.lblTiempoRecreo.Size = new System.Drawing.Size(0, 73);
            this.lblTiempoRecreo.TabIndex = 2;
            // 
            // FrmEvaluados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(611, 528);
            this.ControlBox = false;
            this.Controls.Add(this.lblTiempoRecreo);
            this.Controls.Add(this.lblRecreo);
            this.Controls.Add(this.listBoxRecreo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(70, 70);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvaluados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patio de Recreos";
            this.Load += new System.EventHandler(this.FrmEvaluados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxRecreo;
        private System.Windows.Forms.Timer DuracionRecreo;
        private System.Windows.Forms.Label lblRecreo;
        private System.Windows.Forms.Label lblTiempoRecreo;
    }
}