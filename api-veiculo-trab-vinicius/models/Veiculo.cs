using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_veiculo_trab_vinicius.models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]

        public string NomeVeiculo { get; set; }

        public int AnoVeiculo { get; set; }
        public string Observacao { get; set; }

        public int ModeloId { get; set; }

        public Modelo Modelo { get; set; }


    }
}
