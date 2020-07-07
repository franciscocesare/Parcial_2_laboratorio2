using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Cesare.Francisco._2D
{
    public partial class FrmEvaluados : Form
    {
        int tiempoRecreo = 0;
        List<Alumno> alumnosRecreo;

        public FrmEvaluados()
        {
            InitializeComponent();
            lblRecreo.Visible = false;
            DuracionRecreo.Enabled = true;
            DuracionRecreo.Start();
      
        }


        public List<Alumno> AlumnosRecreo
        {
            get { return this.alumnosRecreo; }
            set { this.alumnosRecreo = value; }
        }

        public void MostrarRecreo() ///supuestamente le paso un alumno, no el control
        {
            try
            {
                if (listBoxRecreo.InvokeRequired)
                {
                    listBoxRecreo.BeginInvoke((MethodInvoker)delegate
                    {
                        listBoxRecreo.DataSource = alumnosRecreo.ToList(); 
                    });
                }
                else
                {

                    listBoxRecreo.DataSource = alumnosRecreo.ToList();
               
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

              ///llega null
        }

        private void DuracionRecreo_Tick(object sender, EventArgs e)
        {

            if (tiempoRecreo == 5)
            {
                tiempoRecreo = 0;
                this.Hide(); ///si paso el recreo cierro el form?
            }
            tiempoRecreo ++;
        }

        private void FrmEvaluados_Load(object sender, EventArgs e)
        {

            MostrarRecreo();
            lblRecreo.Visible = true;
        }
    }
}
