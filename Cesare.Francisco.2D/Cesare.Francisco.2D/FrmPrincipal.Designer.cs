namespace Cesare.Francisco._2D
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.btnComenzar = new System.Windows.Forms.Button();
            this.lblConexion = new System.Windows.Forms.Label();
            this.lblTiempoEvaluando = new System.Windows.Forms.Label();
            this.timerEvaluaciones = new System.Windows.Forms.Timer(this.components);
            this.lblAlumnosSinEvaluar = new System.Windows.Forms.Label();
            this.listBoxAlumnos = new System.Windows.Forms.ListBox();
            this.txtBoxAlumnoEvaluado = new System.Windows.Forms.TextBox();
            this.txtBoxDocenteEvalua = new System.Windows.Forms.TextBox();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnComenzar
            // 
            this.btnComenzar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComenzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzar.ImageKey = "(ninguno)";
            this.btnComenzar.Location = new System.Drawing.Point(338, 220);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(108, 54);
            this.btnComenzar.TabIndex = 3;
            this.btnComenzar.Text = "Comenzar Evaluacion";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.Location = new System.Drawing.Point(343, 207);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(0, 13);
            this.lblConexion.TabIndex = 2;
            // 
            // lblTiempoEvaluando
            // 
            this.lblTiempoEvaluando.AutoSize = true;
            this.lblTiempoEvaluando.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoEvaluando.Location = new System.Drawing.Point(337, 314);
            this.lblTiempoEvaluando.Name = "lblTiempoEvaluando";
            this.lblTiempoEvaluando.Size = new System.Drawing.Size(0, 37);
            this.lblTiempoEvaluando.TabIndex = 3;
            // 
            // timerEvaluaciones
            // 
            this.timerEvaluaciones.Interval = 1000;
            this.timerEvaluaciones.Tick += new System.EventHandler(this.timerEvaluaciones_Tick);
            // 
            // lblAlumnosSinEvaluar
            // 
            this.lblAlumnosSinEvaluar.AutoSize = true;
            this.lblAlumnosSinEvaluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnosSinEvaluar.Location = new System.Drawing.Point(3, 20);
            this.lblAlumnosSinEvaluar.Name = "lblAlumnosSinEvaluar";
            this.lblAlumnosSinEvaluar.Size = new System.Drawing.Size(261, 20);
            this.lblAlumnosSinEvaluar.TabIndex = 4;
            this.lblAlumnosSinEvaluar.Text = "Alumnos  Random para Evaluar";
            // 
            // listBoxAlumnos
            // 
            this.listBoxAlumnos.FormattingEnabled = true;
            this.listBoxAlumnos.Location = new System.Drawing.Point(40, 53);
            this.listBoxAlumnos.Name = "listBoxAlumnos";
            this.listBoxAlumnos.Size = new System.Drawing.Size(138, 368);
            this.listBoxAlumnos.TabIndex = 0;
            // 
            // txtBoxAlumnoEvaluado
            // 
            this.txtBoxAlumnoEvaluado.Location = new System.Drawing.Point(328, 176);
            this.txtBoxAlumnoEvaluado.Name = "txtBoxAlumnoEvaluado";
            this.txtBoxAlumnoEvaluado.Size = new System.Drawing.Size(190, 20);
            this.txtBoxAlumnoEvaluado.TabIndex = 2;
            // 
            // txtBoxDocenteEvalua
            // 
            this.txtBoxDocenteEvalua.Location = new System.Drawing.Point(256, 53);
            this.txtBoxDocenteEvalua.Name = "txtBoxDocenteEvalua";
            this.txtBoxDocenteEvalua.Size = new System.Drawing.Size(190, 20);
            this.txtBoxDocenteEvalua.TabIndex = 1;
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAlumno.Location = new System.Drawing.Point(335, 156);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(135, 17);
            this.lblNombreAlumno.TabIndex = 4;
            this.lblNombreAlumno.Text = "Alumno a Evaluar";
            // 
            // lblNombreDocente
            // 
            this.lblNombreDocente.AutoSize = true;
            this.lblNombreDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDocente.Location = new System.Drawing.Point(184, 54);
            this.lblNombreDocente.Name = "lblNombreDocente";
            this.lblNombreDocente.Size = new System.Drawing.Size(68, 17);
            this.lblNombreDocente.TabIndex = 4;
            this.lblNombreDocente.Text = "Docente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tiempo Evaluando";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(537, 470);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxDocenteEvalua);
            this.Controls.Add(this.txtBoxAlumnoEvaluado);
            this.Controls.Add(this.listBoxAlumnos);
            this.Controls.Add(this.lblNombreDocente);
            this.Controls.Add(this.lblNombreAlumno);
            this.Controls.Add(this.lblAlumnosSinEvaluar);
            this.Controls.Add(this.lblTiempoEvaluando);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.btnComenzar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aula De Evaluacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.Label lblTiempoEvaluando;
        private System.Windows.Forms.Timer timerEvaluaciones;
        private System.Windows.Forms.Label lblAlumnosSinEvaluar;
        private System.Windows.Forms.ListBox listBoxAlumnos;
        private System.Windows.Forms.TextBox txtBoxAlumnoEvaluado;
        private System.Windows.Forms.TextBox txtBoxDocenteEvalua;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.Label lblNombreDocente;
        private System.Windows.Forms.Label label2;
    }
}

