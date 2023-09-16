using System.ComponentModel.DataAnnotations;

namespace ApiSalesData.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string email { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string empresa { get; set; }

        public string fechaCreacion { get; set; }

        public string pais { get; set; }

    }
}
