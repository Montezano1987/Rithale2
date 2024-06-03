namespace Rithale2.Entities
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string cpf, string email, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, CPF: {CPF}, Email: {Email}, Telefone: {Telefone}";
        }
    }
}
