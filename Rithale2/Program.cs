using Rithale2.Entities;
using Rithale2.Entities.Enums;
using System.IO;

namespace Rhitale2
{

    class Program
    {
        static List<Cliente> clientes = new List<Cliente>
    {
        new Cliente("Bruno Montezano", "08702114631", "brunovmontezano@gmail.com" , "32998261225"),
        new Cliente("Davi Filgueiras", "12345678900", "coyote@hotmail.com", "34627070")

    };
        static List<Profissional> profissionais = new List<Profissional>
    {
        new Profissional("Thamiris Montezano", "Biomedica"),
        new Profissional("Aline Ribeiro", "Esteticista"),
        new Profissional("Andreia", "Massoterapeuta"),
        new Profissional("Cassiane", "Manicure"),
    };

        static List<Servico> servicos = new List<Servico>
    {
        new Servico("Depilação a Laser", 200.00),
        new Servico("Limpeza de Pele", 80.00),
        new Servico("Massagem", 100.00),
        new Servico("Mão e Pé", 50.00),
    };

        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindos a Clínica Rhitale");
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Ver informações sobre os profissionais");
            Console.WriteLine("2. Ver informações sobre os serviços");
            Console.WriteLine("3. Cadastrar Cliente");
            Console.WriteLine("4. Remover Cliente");
            Console.WriteLine("5. Cadastrar Funcionário");
            Console.WriteLine("6. Remover Funcionário");
            Console.WriteLine("7. Realizar Agendamento");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                MostrarProfissionais();
            }
            else if (opcao == "2")
            {
                MostrarServicos();
            }
            else if (opcao == "3")
            {
                CadastrarCliente();
            }
            else if (opcao == "4")
            {
                RemoverCliente();
            }
            else if (opcao == "5")
            {
                CadastrarFuncionario();
            }
            else if (opcao == "6")
            {
                RemoverFuncionario();
            }
            else if (opcao == "7")
            {
                RealizarAgendamento();
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                MostrarMenuPrincipal();
            }
        }

        static void MostrarProfissionais()
        {
            Console.WriteLine("Profissionais:");
            foreach (var profissional in profissionais)
            {
                Console.WriteLine(profissional.ToString());
            }
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void MostrarServicos()
        {
            Console.WriteLine("Serviços:");
            foreach (var servico in servicos)
            {
                Console.WriteLine(servico.ToString());
            }
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void CadastrarCliente()
        {
            
            bool clienteExistente = false;

            Console.Write("Digite seu CPF:");
            string cpf = Console.ReadLine();

            foreach (var cliente in clientes)
            {
                if (cliente.CPF == cpf)
                {
                    clienteExistente = true;
                    break;
                }
            }
            if (clienteExistente)
            {
                Console.WriteLine("Cliente já existe");
                MostrarMenuPrincipal();
            }
            else
            {
                Console.WriteLine("Cadastro de Cliente:");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Telefone: ");
                string telefone = Console.ReadLine();

                Cliente cliente = new Cliente(nome, cpf, email, telefone);
                clientes.Add(cliente);

                Console.WriteLine("Cliente cadastrado com sucesso!");
                Console.WriteLine();
                MostrarMenuPrincipal();
            }
        }


        static void RemoverCliente()
        {
            Console.WriteLine("Remover Cliente:");
            Console.Write("Nome do cliente a ser removido: ");
            string nome = Console.ReadLine();

            Cliente cliente = clientes.Find(cliente => cliente.Nome == nome);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }

            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void CadastrarFuncionario()
        {
            Console.WriteLine("Cadastro de Funcionário:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Especialidade: ");
            string especialidade = Console.ReadLine();

            bool funcionarioExistente = false;
            foreach (var funcionario in profissionais)
            {
                if (funcionario.Nome == nome)
                {
                    funcionarioExistente = true;
                    break;
                }
            }

            if (funcionarioExistente)
            {
                Console.WriteLine("Funcionário já existente");
            }
            else
            {
                Profissional profissional = new Profissional(nome, especialidade);
                profissionais.Add(profissional);
                Console.WriteLine("Funcionário cadastrado com sucesso!");
            }

            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void RemoverFuncionario()
        {
            Console.WriteLine("Remover Funcionário:");
            Console.Write("Número do funcionário a ser removido: ");
            int numeroFuncionario = int.Parse(Console.ReadLine());

            if (numeroFuncionario >= 1 && numeroFuncionario <= profissionais.Count)
            {
                profissionais.RemoveAt(numeroFuncionario - 1);
                Console.WriteLine("Funcionário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Número de funcionário inválido!");
            }

            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void RealizarAgendamento()
        {

            static Profissional EscolherProfissional()
            {
                Console.WriteLine("Escolha um profissional:");
                int i = 1;
                foreach (var profissional in profissionais)
                {
                    Console.WriteLine($"{i}. {profissional}");
                    i++;
                }

                int escolha;
                while (true)
                {
                    Console.Write("Opção: ");

                    {
                        escolha = int.Parse(Console.ReadLine());
                        if (escolha >= 1 && escolha <= profissionais.Count)
                        {
                            return profissionais[escolha - 1];
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Tente novamente.");
                        }
                    }
                }
            }
            static Servico EscolherServico()
            {
                Console.WriteLine("Escolha um serviço:");
                int i = 1;
                foreach (var servico in servicos)
                {
                    Console.WriteLine($"{i}. {servico}");
                    i++;
                }

                int escolha;
                while (true)
                {
                    Console.Write("Opção: ");
                    escolha = int.Parse(Console.ReadLine());
                    if (escolha >= 1 && escolha <= servicos.Count)
                    {
                        return servicos[escolha - 1];
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }
            }


            static DateTime EscolherDataEHora()
            {
                Console.WriteLine("Escolha uma data e hora para o agendamento:");
                return DateTime.Parse(Console.ReadLine());
            }
        }
    }
}
