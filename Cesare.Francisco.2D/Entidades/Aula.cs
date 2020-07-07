using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aula
    {
        private int idAula;
        private string salita;

        public Aula()
        {
        }
        public Aula(int idAula, string salita)
        {
            this.idAula = idAula;
            this.salita = salita;

        }

        public int IDaula
        {
            get { return this.idAula; }
            set { this.idAula = value; }
        }


        public string Salita
        {
            get { return this.salita; }
            set { this.salita = value; }
        }


    }
}
