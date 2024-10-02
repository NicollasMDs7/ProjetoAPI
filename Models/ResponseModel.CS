using WebAPI8_Trainne.Migrations;

namespace WebAPI8_Trainne.Models
{
    public class ResponseModel <T>
    {
        public T? Dados { get; set; }
        public String Mensagem {  get; set; }
        public bool Status {  get; set; } = true;
    }
}
