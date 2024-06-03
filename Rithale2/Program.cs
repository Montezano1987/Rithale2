using System;
using Rithale2.Entities;
using Rithale2.Entities.Enums;

namespace Rhitale2
{

    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
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
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        MostrarProfissionais();
                        break;
                    case 2:
                        MostrarServicos();
                        break;
                    case 3:
                        CadastrarCliente();
                        break;
                    case 4:
                        RemoverCliente();
                        break;
                    case 5:
                        CadastrarFuncionario();
                        break;
                    case 6:
                        RemoverFuncionario();
                        break;
                    case 7:
                        RealizarAgendamento();
                        break;
                    case 8:
                        RemoverAgendamento();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        MostrarMenuPrincipal();
                        break;
                }
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
                Console.WriteLine($"- {profissional.Nome}: {profissional.Especialidade}");
            }
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void MostrarServicos()
        {
            Console.WriteLine("Serviços:");
            foreach (var servico in servicos)
            {
                Console.WriteLine($"- {servico.Nome}: R${servico.Preco:F2}");
            }
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("Cadastro de Cliente:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
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

        static void RemoverCliente()
        {
            Console.WriteLine("Remover Cliente:");
            Console.Write("CPF do cliente a ser removido: ");
            string cpf = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.CPF == cpf);
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

            Profissional profissional = new Profissional(nome, especialidade);
            profissionais.Add(profissional);

            Console.WriteLine("Funcionário cadastrado com sucesso!");
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void RemoverFuncionario()
        {
            Console.WriteLine("Remover Funcionário:");
            Console.Write("Nome do funcionário a ser removido: ");
            string nome = Console.ReadLine();

            Profissional profissional = profissionais.Find(p => p.Nome == nome);
            if (profissional != null)
            {
                profissionais.Remove(profissional);
                Console.WriteLine("Funcionário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }

            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void RealizarAgendamento()
        {
            Cliente cliente = CriarCliente();
            Profissional profissional = EscolherProfissional();
            Servico servico = EscolherServico();
            DateTime data = EscolherData();

            Agendamento agendamento = new Agendamento(cliente, profissional, servico, data, StatusAgendamento.Pendente);

            Console.WriteLine("Detalhes do Agendamento:");
            Console.WriteLine(agendamento);
            Console.WriteLine();
            MostrarMenuPrincipal();
        }

        static void RemoverAgendamento()
        {
            Console.WriteLine("Remover Agendamento:");
            Console.Write("CPF do cliente a ser removido: ");
            string cpf = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.CPF == cpf);
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

        static Cliente CriarCliente()
        {
            Console.WriteLine("Informe os dados do cliente:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            return new Cliente(nome, cpf, email, telefone);
        }

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
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= profissionais.Count)
                {
                    return profissionais[escolha - 1];
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
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
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= servicos.Count)
                {
                    return servicos[escolha - 1];
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
        }

        static DateTime EscolherData()
        {
            Console.WriteLine("Escolha uma data para o agendamento e hora:");
            DateTime data;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.WriteLine("Formato de data e hora inválido. Tente novamente.");
                Console.Write("Data e Hora (dd/MM/yyyy HH:mm): ");
            }

            return data;
        }
    }
}