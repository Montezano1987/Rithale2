using System.Data;
using Rithale2.Entities;
using Rithale2.Entities.Enums;

public static class BancoDeDados
{
    public static string CaminhoTabelaCliente = "C:\\Projetos\\Rithale2\\tabelaCliente.txt";

    public static string CaminhoTabelaProfissional = @"C:\Projetos\Rithale2\tabelaProfissional.txt";

    public static string CaminhoTabelaAgendamento = @"C:\Projetos\Rithale2\tabelaAgendamento.txt";

    public static string CaminhoTabelaServico = @"C:\Projetos\Rithale2\tabelaServico.txt";
    public static void GravarCliente(Cliente cliente)
    {
        var clienteConcatenado = cliente.Nome + ";" + cliente.Telefone + ";" + cliente.CPF + ";" + cliente.Email;
        File.AppendAllText(CaminhoTabelaCliente, clienteConcatenado + Environment.NewLine);
    }
    public static List<Cliente> BuscarClientes()
    {
        string[] linhasClientes = File.ReadAllLines(CaminhoTabelaCliente);
        var clientes = new List<Cliente>();
        foreach (string stringClienteConcatenado in linhasClientes)
        {
            var propriedadesCliente = stringClienteConcatenado.Split(';');
            var cliente = new Cliente(propriedadesCliente[0], propriedadesCliente[1], propriedadesCliente[2], propriedadesCliente[3]);
            clientes.Add(cliente);
        }

        return clientes;
    }
    public static void GravarProfissionais(Profissional profissional)
    {
        var profissionalconcatenado = profissional.Nome + ";" + profissional.Especialidade + Environment.NewLine;
        File.AppendAllText(CaminhoTabelaProfissional, profissionalconcatenado);
    }

    public static List<Profissional> BuscarProfissionais()
    {
        string[] linhasProfissionais = File.ReadAllLines(CaminhoTabelaProfissional);
        var profissionais = new List<Profissional>();
        foreach (string stringProfissionalConcatenado in linhasProfissionais)
        {
            var propriedadesProfissional = stringProfissionalConcatenado.Split(';');
            var profissional = new Profissional(propriedadesProfissional[0], propriedadesProfissional[1]);
            profissionais.Add(profissional);
        }

        return profissionais;
    }

    public static void GravarAgendamento(Agendamento agendamento)
    {
        var agendamentoConcatenado = agendamento.Cliente.Nome + "," + agendamento.Cliente.CPF + "," + agendamento.Cliente.Email + "," + agendamento.Cliente.Telefone
            + ";" + agendamento.Profissional.Nome + "," + agendamento.Profissional.Especialidade
            + ";" + agendamento.Servico.Nome + "," + agendamento.Servico.Preco
            + ";" + agendamento.Data
            + ";" + agendamento.Status + Environment.NewLine;
        File.AppendAllText(CaminhoTabelaAgendamento, agendamentoConcatenado);
    }

    public static List<Agendamento> BuscarAgendamentos()
    {
        string[] linhasAgendamentos = File.ReadAllLines(CaminhoTabelaAgendamento);
        var agendamentos = new List<Agendamento>();
        foreach (string stringAgendamentoConcatenado in linhasAgendamentos)
        {
            var propriedadesAgendamento = stringAgendamentoConcatenado.Split(';');

            var propriedadesCliente = propriedadesAgendamento[0].Split(',');
            var cliente = new Cliente(propriedadesCliente[0], propriedadesCliente[1], propriedadesCliente[2], propriedadesCliente[3]);

            var propriedadesProfissional = propriedadesAgendamento[1].Split(',');
            var profissional = new Profissional(propriedadesProfissional[0], propriedadesProfissional[1]);

            var propriedadesServico = propriedadesAgendamento[2].Split(',');
            var servico = new Servico(propriedadesServico[0], double.Parse(propriedadesServico[1]));

            var data = DateTime.Parse(propriedadesAgendamento[3]);
            var status = StatusAgendamento.Pendente;
            var agendamento = new Agendamento(cliente, profissional, servico, data, status);
            agendamentos.Add(agendamento);
        }

        return agendamentos;
    }
}

