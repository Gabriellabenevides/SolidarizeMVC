using System.ComponentModel.DataAnnotations;

namespace SolidarizeMVC.Models
{
    public class DoacaoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o ID do doador!")]
        public int DoadorId { get; set; }
        public DoadorModel? Doador { get; set; }
        [Required(ErrorMessage = "Digite o ID da Campanha!")]
        public int CampanhaId { get; set; }
        public CampanhaModel? Campanha { get; set; }
        [Required(ErrorMessage = "Digite o valor da doação!")]
        public decimal ValorDoacao { get; set; }
        [Required(ErrorMessage = "Digite a data da doação!")]
        public DateTime DataDoacao { get; set; } = DateTime.Now;

        public DoacaoModel() { }
    }
}
