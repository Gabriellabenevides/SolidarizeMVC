using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SolidarizeMVC.Models
{
    public class CampanhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da Campanha!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a descrição da Campanha!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o Valor Objetivo!")]
        public decimal ValorObjetivo { get; set; }
        [Required(ErrorMessage = "Digite a Data de início!")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Digite a Data final!")]
        public DateTime DataFinal { get; set; }
        public ICollection<DoacaoModel> Doacoes { get; set; }
        [Required(ErrorMessage = "Escolha o Status!")]
        public StatusCampanha Status { get; set; }

        public enum StatusCampanha
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            Aberta,
            Concluida,
            Cancelada
        }
        public CampanhaModel()
        {
            Doacoes = new List<DoacaoModel>();
        }
    }
}
