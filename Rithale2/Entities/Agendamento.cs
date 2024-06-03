using Rithale2.Entities.Enums;

namespace Rithale2.Entities
{
    public class Agendamento
    {
        public Cliente Cliente { get; set; }
        public Profissional Profissional { get; set; }
        public Servico Servico { get; set; }
        public DateTime Data { get; set; }
        public StatusAgendamento Status { get; set; }

        public Agendamento(Cliente cliente, Profissional profissional, Servico servico, DateTime data, StatusAgendamento status)
        {
            Cliente = cliente;
            Profissional = profissional;
            Servico = servico;
            Data = data;
            Status = status;
        }

        public override string ToString()
        {
            return $"Cliente: {Cliente}, Profissional: {Profissional}, Serviço: {Servico}, Data: {Data}, Status: {Status}";
        }
    }
}
