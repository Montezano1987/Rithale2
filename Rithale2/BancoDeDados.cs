using System.IO;
using Rithale2.Entities;

public static class BancoDeDados
{
    public static string CaminhoTabelaCliente = "c://TabelaClientes.txt";
    public static void GravarCliente(Cliente cliente)
    {

        var clienteString = "Bruno Montezano;12121212;brunovmontezano@gmail.com;32998261225";

        File.WriteAllText(CaminhoTabelaCliente, clienteString + Environment.NewLine);
    }

    public static void BuscarClientes()
    {;
        string listaClientes = File.ReadAllText(CaminhoTabelaCliente);
    }
}

