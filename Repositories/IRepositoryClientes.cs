using ApiSalesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSalesData.Repositories
{
    public interface IRepositoryClientes
    {
        List<Cliente> GetClientes();

        Cliente BuscarCliente(int idCliente);

        void EliminarCliente(int idcliente);

        void PostClientes(string email, string nombre, string apellido, string empresa, string pais);

        void ModificarCliente(int idCliente, String email, String nombre, String apellido, String empresa, String fechaCreacion, String pais);
    }
}
