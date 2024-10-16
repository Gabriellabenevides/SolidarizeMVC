using System.Text.Json.Serialization;

namespace SolidarizeMVC.Models
{
    public class DoadorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public ICollection<DoacaoModel> Doacoes { get; set; }
    }
}
