namespace SolidarizeMVC.Models
{
    public class DoacaoModel
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DoadorModel Doador { get; set; }
        public int CampanhaId { get; set; }
        public CampanhaModel Campanha { get; set; }
        public decimal ValorDoacao { get; set; }
        public DateTime DataDoacao { get; set; } = DateTime.Now;
    }
}
