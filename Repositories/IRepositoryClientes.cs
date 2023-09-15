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

        void PostClientes(Cliente cliente);

        void ModificarCliente(Cliente cliente);
    }
}
