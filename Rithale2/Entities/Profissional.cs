namespace Rithale2.Entities;
public class Profissional
{
    public string Nome {  get; set; }
    public string Especialidade { get; set; }

    public Profissional(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Especialidade: {Especialidade}";
    }
}
