using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Entidades
{

    [Serializable]
    public class Alumno : Persona
    {
        

        private int responsable;
        private float notaFinal;

        public Alumno()
        {

        }
        public Alumno(string nombre, string apellido, int edad, int dni, int iD, string direccion, int responsable) : base(nombre, apellido, edad, dni, iD, direccion)
        {
            this.Responsable = responsable;

        }

        public float NotaFinal
        {
            get { return this.notaFinal; }
            set { this.notaFinal = value; }
        }

        public int Responsable
        {
            get { return this.responsable; }
            set { this.responsable = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Nombre.ToString());
            sb.AppendLine(", ");
            sb.AppendLine(base.Apellido.ToString());

            return sb.ToString();
        }

        public static List<Alumno> CargarAlumnosDeBase<T>(List<Alumno> Alumnos, SqlConnection conexion)
        {
            SqlConnection miConex = conexion;

            SqlDataReader dr = ManejadorSql<Alumno>.EjecutarConsulta("SELECT * FROM Alumnos", null, miConex);

            while (dr.Read())
            {
                Alumnos.Add(new Alumno
                    (dr[1].ToString(),
                     dr[2].ToString(),
                    int.Parse(dr[3].ToString()),
                    int.Parse(dr[4].ToString()),
                    int.Parse(dr[0].ToString()),
                     dr[5].ToString(),
                     int.Parse(dr[6].ToString())));
            }
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return Alumnos;
        }




    }
}
