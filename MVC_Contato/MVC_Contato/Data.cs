using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Contato
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get=> ano; set => ano = value; }

        public void setData(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override String ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano}";
        }
    }
}
