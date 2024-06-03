    namespace Rithale2.Entities;
    public class Servico
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Servico(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Serviço: {Nome}, Preço: {Preco:C2}";
        }
    }
