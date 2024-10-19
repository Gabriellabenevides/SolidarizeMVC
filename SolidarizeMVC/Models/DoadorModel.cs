using System.ComponentModel.DataAnnotations;

namespace SolidarizeMVC.Models
{
    public class DoadorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do doador!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do doador!")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do doador!")]
        public string Email { get; set; }
        public ICollection<DoacaoModel> Doacoes { get; set; }

        public DoadorModel()
        {
            Doacoes = new List<DoacaoModel>(); 
        }
    }
}
