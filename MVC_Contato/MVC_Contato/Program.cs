using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Contato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int option;

            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("| 0. Sair                            |");
                Console.WriteLine("| 1. Adicionar contato               |");
                Console.WriteLine("| 2. Pesquisar contato               |");
                Console.WriteLine("| 3. Alterar contato                 |");
                Console.WriteLine("| 4. Remover contato                 |");
                Console.WriteLine("| 5. Listar contatos                 |");
                Console.WriteLine("--------------------------------------");
                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AdicionarContato(agenda);
                        break;
                    case 2:
                        PesquisarContato(agenda);
                        break;
                    case 3:
                        AlterarContato(agenda);
                        break;
                    case 4:
                        RemoverContato(agenda);
                        break;
                    case 5:
                        ListarContatos(agenda);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine();

            } while (option != 0);
        }

        static void AdicionarContato(Contatos agenda)
        {
            Contato novoContato = new Contato();
            Console.Write("Digite o nome: ");
            novoContato.Nome = Console.ReadLine();
            Console.Write("Digite o email: ");
            novoContato.Email = Console.ReadLine();

            Data dtNasc = new Data();
            Console.Write("Digite o dia de nascimento: ");
            dtNasc.Dia = int.Parse(Console.ReadLine());
            Console.Write("Digite o mês de nascimento: ");
            dtNasc.Mes = int.Parse(Console.ReadLine());
            Console.Write("Digite o ano de nascimento: ");
            dtNasc.Ano = int.Parse(Console.ReadLine());
            novoContato.DtNasc = dtNasc;

            novoContato.Telefones = new List<Telefone>();

            bool telefonePrincipalAdicionado = false;

            string adicionarOutroTelefone;
            do
            {
                Telefone telefone = new Telefone();
                Console.Write("Digite o tipo do telefone: ");
                telefone.Tipo = Console.ReadLine();
                Console.Write("Digite o número do telefone: ");
                telefone.Numero = Console.ReadLine();
                Console.Write("Este telefone é o principal? (true/false): ");
                telefone.Principal = bool.Parse(Console.ReadLine());

                if (telefone.Principal)
                {
                    telefonePrincipalAdicionado = true;
                }

                novoContato.addTelefone(telefone);

                Console.Write("Deseja adicionar outro telefone? (s/n): ");
                adicionarOutroTelefone = Console.ReadLine().ToLower();

            } while (adicionarOutroTelefone == "s");

            if (!telefonePrincipalAdicionado)
            {
                Console.WriteLine("Erro: Você deve adicionar pelo menos um telefone principal.");
                return; 
            }

            if (agenda.adicionar(novoContato))
            {
                Console.WriteLine("Contato adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato já existe na agenda.");
            }
        }

        static void PesquisarContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato: ");
            string email = Console.ReadLine();
            Contato contato = agenda.pesquisar(email);

            if (contato != null)
            {
                Console.WriteLine("Contato encontrado: " + contato.ToString());
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void AlterarContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato a ser alterado: ");
            string email = Console.ReadLine();
            Contato contato = agenda.pesquisar(email);

            if (contato != null)
            {
                Console.Write("Novo nome: ");
                contato.Nome = Console.ReadLine();

                Data dtNasc = new Data();
                Console.Write("Novo dia de nascimento: ");
                dtNasc.Dia = int.Parse(Console.ReadLine());
                Console.Write("Novo mês de nascimento: ");
                dtNasc.Mes = int.Parse(Console.ReadLine());
                Console.Write("Novo ano de nascimento: ");
                dtNasc.Ano = int.Parse(Console.ReadLine());
                contato.DtNasc = dtNasc;

                Console.Write("Digite o tipo do novo telefone: ");
                Telefone telefone = new Telefone();
                telefone.Tipo = Console.ReadLine();
                Console.Write("Digite o número do novo telefone: ");
                telefone.Numero = Console.ReadLine();
                Console.Write("Este telefone é o principal? (true/false): ");
                telefone.Principal = bool.Parse(Console.ReadLine());

                contato.Telefones.Clear();
                contato.addTelefone(telefone);

                if (agenda.alterar(contato))
                {
                    Console.WriteLine("Contato alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro ao alterar o contato.");
                }
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void RemoverContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato a ser removido: ");
            string email = Console.ReadLine();
            Contato contato = agenda.pesquisar(email);

            if (contato != null)
            {
                if (agenda.remover(contato))
                {
                    Console.WriteLine("Contato removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro ao remover o contato.");
                }
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void ListarContatos(Contatos agenda)
        {
            if (agenda.Agenda.Count == 0)
            {
                Console.WriteLine("Não há contatos na agenda.");
                return;
            }

            Console.WriteLine("Lista de contatos:");
            foreach (var contato in agenda.Agenda)
            {
                Console.WriteLine(contato.ToString());
            }
        }
    }
}
