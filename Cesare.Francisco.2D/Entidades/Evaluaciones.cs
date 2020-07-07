using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class Evaluaciones

    {
        public enum EObservaciones
        {
            Felicitaciones,
            PodemosMejorar

        }

       private int idAlumno;
       private int idDocente;
       private int idAula;
       private int nota_1;
       private int nota_2;
       private float notaFinal;
       private string observaciones;

        public Evaluaciones()
        {

        }
        public Evaluaciones(int idAlumno, int idDocente, int idAula, int nota_1, int nota_2, float notaFinal, string observaciones)
        {
            this.idAlumno = idAlumno;
            this.idDocente = idDocente;
            this.idAula = idAula;
            this.nota_1 = nota_1;
            this.nota_2 = nota_2;
            this.notaFinal = notaFinal;
            this.observaciones = observaciones;
        }

        public int IDalumno
        {
            get { return this.idAlumno; }
            set { this.idAlumno = value; }
        }

        public int IDDocente
        { 
            get { return this.idDocente; }
            set { this.idDocente = value; }
        }
        public int IDAula
{
            get { return this.idAula; }
            set { this.idAula = value; }
        }
        public int Nota_1
{
            get { return this.nota_1; }
            set { this.nota_1 = value; }
        }
        public int Nota_2
{
            get { return nota_2; }
            set {nota_2 = value; }
        }
        public float NotaFinal
{
            get { return this.notaFinal; }
            set { this.notaFinal = value; }
        }
        public string Observaciones
{
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        public static void CargarEvaluacionesEnBase<T>(Evaluaciones  evaluacion, SqlConnection conexion)
        {
            try
            {
                SqlConnection miConex = conexion;

                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("idAlumno", evaluacion.IDalumno));
                parameters.Add(new SqlParameter("idDocente", evaluacion.IDDocente));
                parameters.Add(new SqlParameter("idAula", evaluacion.IDAula));
                parameters.Add(new SqlParameter("Nota_1", evaluacion.Nota_1));
                parameters.Add(new SqlParameter("Nota_2", evaluacion.Nota_2));
                parameters.Add(new SqlParameter("NotaFinal", evaluacion.NotaFinal));
                parameters.Add(new SqlParameter("Observaciones", evaluacion.Observaciones));

                ////// si falla algo, aca saque el if >1
                ManejadorSql<Alumno>.EjecutarComando("INSERT INTO Evaluaciones (idAlumno,idDocente,idAula,Nota_1,Nota_2,NotaFinal,Observaciones)"
               + "VALUES (@idAlumno,@idDocente,@idAula, @Nota_1,@Nota_2,@NotaFinal, @Observaciones)", parameters, miConex);

            }
            catch (Exception ex)
            {
               throw new Exception (ex.Message);  ///lanzar algo piola  throw new ArchivosException(e);
            }
   
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine(base.Nombre.ToString());
        //    sb.AppendLine(", ");
        //    sb.AppendLine(base.Apellido.ToString());

        //    return sb.ToString();
        //}

    }

}
