using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Excepciones;

namespace Cesare.Francisco._2D
{

    public delegate void ProximoAlumne(object o);
    public delegate void MoverDeLista(Alumno alumno);
    public delegate void Recreo(List<Alumno> alumnos);

    public partial class FrmPrincipal : Form
    {

        int ciclos = 0;
        int min = 0;
        int tiempoEvaluacion = 0;
        const int RINDIENDO = 3000; //tiempo evaluando
        SqlConnection miConexion;

        List<Thread> hilos;
        List<Alumno> alumnos;
        List<Alumno> evaluados;
        Evaluaciones evaluacion;
        Random random;

        private List<Docente> docentes;
        private List<Aula> aulas;

        public event MoverDeLista AlumnoAprobo;  //seria como tiene temp, que desp es +=llevarContagiado alla
        public event MoverDeLista AlumnoDesaprobo;
        public event ProximoAlumne EvaluarProximo;
        public event MoverDeLista AlumnosEvaluados;
        public event Recreo MandarAlRecreo;


        public FrmPrincipal()
        {
            InitializeComponent();
            miConexion = new SqlConnection(@"Server = DESKTOP-VF38COB\SQLEXPRESS; Database=JardinUtn; Trusted_Connection=True;");
            alumnos = new List<Alumno>();
            docentes = new List<Docente>();
            aulas = new List<Aula>();
            hilos = new List<Thread>();
            evaluados = new List<Alumno>();
            evaluacion = new Evaluaciones();

            random = new Random();

            //asigno lo manejadores
            AlumnosEvaluados += moverAlistaEvaluados;
            EvaluarProximo += proximoAlumno;
            AlumnoAprobo += GuardarAprobados;   //el evento alumno aprobo asigna manejador a Guardar aprobados
            AlumnoDesaprobo += GuardarDesaprobados;  //el evento alumno desaprobo asigna manejador a Guardar aprobados
            MandarAlRecreo += llevaralRecreo;  //esto iria despues del timer?

        }


        #region PROPIEDADES FORM
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //  lblTiempoEvaluando.Text = "aca va ir un cronometro"; /////sacar despues estoooo
            if (ManejadorSql<SqlConnection>.EjecutarConexion(miConexion))
            {
                CargarAulasDeBase<Aula>(Aulas, miConexion);
                this.CargarListaAlumnos();
                LeerDocentesXml();
                CargarDocentesEnBase<Docente>(Docentes, miConexion);

            }
        }

        public Evaluaciones Evaluacion
        {
            get { return this.evaluacion; }
            set { this.evaluacion = value; }
        }

        public List<Aula> Aulas
        {
            get { return this.aulas; }
            set { this.aulas = value; }
        }

        public List<Alumno> Evaluados
        {
            get { return this.evaluados; }
            set { this.evaluados = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Docente> Docentes
        {
            get { return this.docentes; }
            set { this.docentes = value; }
        }

        #endregion
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Elimino los hilos si aun existen
            foreach (Thread item in hilos)
            {
                if (item.IsAlive)
                    item.Abort();
            }
        }

        #region METODOS 

        /// <summary>
        /// METODO PARA CARGAR LAS AULAS AL FORM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aulas"></param>
        /// <param name="conexion"></param>
        /// <returns></returns>
        public static List<Aula> CargarAulasDeBase<T>(List<Aula> aulas, SqlConnection conexion)
        {
            SqlConnection miConex = conexion;

            SqlDataReader dr = ManejadorSql<Alumno>.EjecutarConsulta("SELECT * FROM Aulas", null, miConex);

            while (dr.Read())
            {
                aulas.Add(new Aula(int.Parse(dr[0].ToString()), dr[1].ToString()));

            }
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }

            return aulas;
        }

        /// <summary>
        /// Levanta de un XML una coleccion de Docentes y los guarda en Lista en memoria
        /// </summary>
        /// <returns></returns>
        public bool LeerDocentesXml() 
        {
            ManejarArchivosClass<List<Docente>> xml = new ManejarArchivosClass<List<Docente>>();

            if (xml.Leer("\\Docentes\\Docentes.xml", out docentes))  //los docentes viene crgadors bien
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Guarda el alumno desaprobado en XML a traves del metodo xmlGuardar
        /// </summary>
        /// <param name="alumno"></param>
        public void GuardarDesaprobados(Alumno alumno)  
        {
            DateTime fecha = DateTime.Now;
            ManejarArchivosClass<Alumno> xml = new ManejarArchivosClass<Alumno>();
            xml.Guardar($"\\Serializaciones\\Desaprobados\\{alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", alumno);  
        }

        /// <summary>
        /// Guarda el alumno aprobado en XML a traves del metodo xmlGuardar
        /// </summary>
        /// <param name="alumno"></param> un alumno evaluado
        public void GuardarAprobados(Alumno alumno) 
        {

            DateTime fecha = DateTime.Now;
            ManejarArchivosClass<Alumno> xml = new ManejarArchivosClass<Alumno>();
            xml.Guardar($"\\Serializaciones\\Aprobados\\{ alumno.Apellido}_{alumno.Nombre}_{fecha.ToString("dd_MM_yyyy")}.xml", alumno);

        }


        /// <summary>
        /// /llena el ListBox con los alumnos en Lista
        /// </summary>
        private void CargarAListBox()
        {
            try
            {
                if (listBoxAlumnos.InvokeRequired)
                {
                    listBoxAlumnos.BeginInvoke((MethodInvoker)delegate
                    {
                        listBoxAlumnos.DataSource = alumnos.ToList(); ;
                    });
                }
                else
                {
                    listBoxAlumnos.DataSource = alumnos.ToList();
                }
            }
            catch (Exception e)
            {
                GuardarString.Guardar("LOGS Errores.txt", e.Message.ToString());
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Trae los alumnos de la B de Datos a la lista, invoca a cargarlos a la lista
        /// </summary>
        private void CargarListaAlumnos()
        {
            Alumno.CargarAlumnosDeBase<Alumno>(alumnos, miConexion);
            CargarAListBox();
        }

        /// <summary>
        /// Ingresa la lista docentes 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Docentes"></param> lista de docentes 
        /// <param name="miconex"></param> datos de SqlConnection
        public static void CargarDocentesEnBase<T>(List<Docente> Docentes, SqlConnection miconex)
        {
            SqlConnection connection = miconex;
            foreach (Docente docente in Docentes)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("Dni", docente.Dni));
                parameters.Add(new SqlParameter("Nombre", docente.Nombre));
                parameters.Add(new SqlParameter("Apellido", docente.Apellido));
                parameters.Add(new SqlParameter("Edad", docente.Edad));
                parameters.Add(new SqlParameter("Sexo", docente.Sexo));
                parameters.Add(new SqlParameter("Direccion", docente.Direccion));
                parameters.Add(new SqlParameter("Email", docente.Email));

                ManejadorSql<Docente>.EjecutarComando("INSERT INTO Docentes (Dni,Nombre,Apellido,Edad,Sexo,Direccion,Email)"
                  + "VALUES (@Dni,@Nombre,@Apellido,@Edad,@Sexo,@Direccion,@Email)", parameters, connection); ;
            }
        }

        /// <summary>
        /// Da inicio a la evaluaciones, timer e hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComenzar_Click(object sender, EventArgs e)
        {
            // FrmEvaluados eval = new FrmEvaluados();
            //eval.Show();

            btnComenzar.Enabled = false;
            timerEvaluaciones.Enabled = true;
            timerEvaluaciones.Start();

            if (hilos.Count != 1)    ///HACER OTRO HILO PARA EL RECREO???
            {

                Thread t = new Thread(new ParameterizedThreadStart(proximoAlumno));
                hilos.Add(new Thread(new ParameterizedThreadStart(proximoAlumno)));
                hilos.Add(t);

            }


            if (!hilos[0].IsAlive)
            {
                hilos[0] = new Thread(new ParameterizedThreadStart(proximoAlumno));
                hilos[0].Start(txtBoxAlumnoEvaluado); /////NO SEEE inicia el hiloooo asi pero un form??   // hilos[0].Start(txtBoxDocenteEvalua);
            }

        }

        /// <summary>
        /// Lleva a la lista de evaluados al recreo
        /// </summary>
        /// <param name="a"></param> lista de alumnos evaluados
        private void llevaralRecreo(List<Alumno> a)  ///cuando se dispara mandar al recreo viene aca
        {
            if (alumnos.Count > 0)
            {
                FrmEvaluados eval = new FrmEvaluados(); //instancio el otro FRM
                eval.AlumnosRecreo = a;

                eval.Show();
                // eval.Focus();
            }

        }
        

        /// <summary>
        /// Cronometro en form principal. Dispara evento al recreo
        /// </summary>
        public void Cronometro()
        {
            string minutos = min.ToString();
            tiempoEvaluacion += 1;

            if (tiempoEvaluacion >= 1 && tiempoEvaluacion <= 9)
            {
                lblTiempoEvaluando.Text = $"00:0{minutos}:0{tiempoEvaluacion.ToString()}";

            }

            else if (tiempoEvaluacion > 59)
            {
                min += 1;
                minutos = min.ToString();
                tiempoEvaluacion = 0;
                lblTiempoEvaluando.Text = $"00:0{minutos}:{tiempoEvaluacion.ToString()}";
            }
            else
                lblTiempoEvaluando.Text = $"00:0{minutos}:{tiempoEvaluacion.ToString()}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerEvaluaciones_Tick(object sender, EventArgs e)
        {
            this.Cronometro();

            if (ciclos == 20)
            {
                MandarAlRecreo(evaluados);
                ciclos = 0;
            }
            ciclos++;
        }

        /// <summary>
        /// agrega a la lista evaluado, el alumno que quita de alumnos,y refresca las listas
        /// </summary>
        /// <param name="alumno"></param>
        private void moverAlistaEvaluados(Alumno alumno)
        {
            evaluados.Add(alumno);
            alumnos.Remove(alumno);
            CargarAListBox();
        }

        /// <summary>
        /// elige indice de alumno, de docente, y pasa a Evaluar
        /// </summary>
        /// <param name="textBox"></param>
        private void proximoAlumno(object textBox)  //de aca se va a evaluar
        {
            int indexAzar = random.Next(0, alumnos.Count);
            if (alumnos.Count > 0)
            {
                EvaluarAlumno(alumnos[indexAzar], docentes[random.Next(0, docentes.Count)], (TextBox)textBox);
            }

            else
            {
                if (txtBoxAlumnoEvaluado.InvokeRequired || txtBoxDocenteEvalua.InvokeRequired)
                {
                    txtBoxDocenteEvalua.BeginInvoke((MethodInvoker)delegate
                    {
                        txtBoxAlumnoEvaluado.Text = "Pancho Cesare";
                        txtBoxDocenteEvalua.Text = "Lucas Rodriguez HOOOLA";   ///trae el nombre del alumno seleccionado

                    });
                }
                else
                {
                    txtBoxAlumnoEvaluado.Text = "Pancho Cesare";
                    txtBoxDocenteEvalua.Text = "Lucas Rodriguez HOOOLA"; ;
                }

                ////    txtBoxAlumnoEvaluado.Text = "Pancho Cesare";
                ///// txtBoxDocenteEvalua.Text = "Hooolaaa Lucas";
                timerEvaluaciones.Stop();
                MessageBox.Show($"Terminaron las Evaluaciones en minutos: {lblTiempoEvaluando.Text} segundos Felicitaciones a Todes");
                foreach (Thread item in hilos)
                {
                    if (item.IsAlive)
                        item.Abort();
                }
            }
        }

        /// <summary>
        /// carga los TextBox con los datos del proximo alumno y el docente al Azar
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="mensaje2"></param>
        /// <param name="txt"></param>
        /// <param name="txt2"></param>
        private void VolcarEnTextBox(string mensaje, string mensaje2, TextBox txt, TextBox txt2)
        {
            if (txt.InvokeRequired || txt2.InvokeRequired)
            {
                txt.BeginInvoke((MethodInvoker)delegate
                {
                    txtBoxAlumnoEvaluado.Text = mensaje;
                    txtBoxDocenteEvalua.Text = mensaje2;   ///trae el nombre del alumno seleccionado
                });
            }
            else
            {
                txt.Text = mensaje;
                txt2.Text = mensaje;
            }
        }

        /// <summary>
        /// Inserta los campos de Evaluacion, para despues pasar Nota Final a Alumno
        /// </summary>
        /// <param name="alum"></param> ALUMNO EVALUADO
        /// <param name="doc"></param> DOCENTE QUE EVALUO
        /// 
        void CargarNotasEvaluacion(Alumno alum, Docente doc)
        {
            int nota1 = random.Next(1, 10);
            int nota2 = random.Next(1, 10);
            Evaluacion.IDalumno = alum.Id;
            Evaluacion.IDDocente = doc.Id;
            Evaluacion.IDAula = random.Next(1, 6); /// como le paso el ID aula?!?!?  HACER UN RANDOM COMO DOCENTE
            Evaluacion.Nota_1 = nota1;
            Evaluacion.Nota_2 = nota2;
            Evaluacion.NotaFinal = (nota1 + nota2) / 2;

            if (Evaluacion.NotaFinal >= 4 && nota1 > 4 && nota2 > 4)   ////ACA NO DEBERIA SER EL EVALUACION.NOTAFINAL???
            {
                Evaluacion.Observaciones = "Felicitaciones!";
                Evaluaciones.CargarEvaluacionesEnBase<Evaluaciones>(evaluacion, miConexion);
                AlumnoAprobo(alum);

            }

            else if (Evaluacion.NotaFinal > 4 && nota1 < 4 || Evaluacion.NotaFinal > 4 && nota2 < 4)
            {
                Evaluacion.Observaciones = "Podemos mejorar";
                Evaluaciones.CargarEvaluacionesEnBase<Evaluaciones>(evaluacion, miConexion);
                AlumnoDesaprobo(alum);

            }

            else
            {
                Evaluacion.Observaciones = "No alcanzo";
                Evaluaciones.CargarEvaluacionesEnBase<Evaluaciones>(evaluacion, miConexion);
                AlumnoDesaprobo(alum);

            }

        }

        /// <summary>
        /// LLAMADO POR EL MANEJADOR Evalua, carga, mueve de lista inserta y pasa al proximo
        /// </summary>
        /// <param name="alum"></param>
        /// <param name="doc"></param>
        /// <param name="txt"></param>
        void EvaluarAlumno(Alumno alum, Docente doc, TextBox txt)/////////////////////////////////////////////////////////////////////////////// toque acaaa
        {
            Thread.Sleep(RINDIENDO);

            CargarNotasEvaluacion(alum, doc);
            VolcarEnTextBox("", "", txt, txt);
            VolcarEnTextBox(alum.ToString(), doc.ToString(), txtBoxAlumnoEvaluado, txtBoxDocenteEvalua);
            AlumnosEvaluados(alum); //dispara el evento y lo mueve de lista
            EvaluarProximo(txt); //dispara evento de llamar al proximo

        }




        #endregion
    }
}
