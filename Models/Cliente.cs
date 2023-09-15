namespace ApiSalesData.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string empresa { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string pais { get; set; }

    }
}
