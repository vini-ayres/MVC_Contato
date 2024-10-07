using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Contato
{
    class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public Contato()
        {
            telefones = new List<Telefone>();
        }

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public Data DtNasc { get => dtNasc; set => dtNasc = value; }
        public List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public int getIdade()
        {
            int idade = DateTime.Now.Year - DtNasc.Ano;
            if (DateTime.Now.Month < DtNasc.Mes || (DateTime.Now.Month == DtNasc.Mes && DateTime.Now.Day < DtNasc.Dia))
            {
                idade--; 
            }
            return idade;
        }

        public void addTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone t in telefones)
            {
                if(t.Principal)
                {
                    return t.Numero;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Nome} - {Email} - {DtNasc} - {getTelefonePrincipal()}";
        }

        public override bool Equals (object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Contato c = (Contato)obj;
            return email.Equals(c.email);
        }

    }
}
