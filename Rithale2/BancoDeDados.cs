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
        var agendamentoConcatenado = agendamento.Cliente + ";" + agendamento.Profissional + ";" + agendamento.Servico + ";" + agendamento.Data + ";" + agendamento.Status + Environment.NewLine;
        File.AppendAllText(CaminhoTabelaAgendamento, agendamentoConcatenado);
    }

    //public static List<Agendamento> BuscarAgendamentos()
    //{
    //    string[] linhasAgendamento = File.ReadAllLines(CaminhoTabelaAgendamento);
    //    var agendamentos = new List<Agendamento>();
    //    foreach (string stringAgendamentoConcatenado in linhasAgendamento)
    //    {
    //        var propriedadesAgendamento = stringAgendamentoConcatenado.Split(';');
    //        var bruno = propriedadesAgendamento[0];
    //        var agendamento = new Agendamento(propriedadesAgendamento[0], propriedadesAgendamento[1], propriedadesAgendamento[2], propriedadesAgendamento[3], propriedadesAgendamento[4]);
    //        var agendamento2 = new Agendamento();
    //        agendamento2.Cliente = 
    //        agendamentos.Add(agendamento);
    //    }

    //    return agendamentos;
    //}
}