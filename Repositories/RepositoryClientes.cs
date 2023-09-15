using ApiSalesData.Controllers;
using ApiSalesData.Data;
using ApiSalesData.Models;
using ApiSalesData.Data;
using ApiSalesData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiSalesData.Repositories
{
    public class RepositoryClientes : IRepositoryClientes
    {

        private ClienteContext context;

        public RepositoryClientes(ClienteContext context)
        {
            this.context = context;
        }

       
        public List<Cliente> GetClientes()
        {
            var consulta = (from datos in this.context.Cliente
                            select datos);
            return consulta.ToList();
        }

       
        public void PostClientes(Cliente cliente)
        {
            var consulta = from datos in this.context.Cliente
                           select datos.Id;


            int maxId = consulta.Max();

            Cliente cli = new Cliente();
            cli.Id = maxId + 1;
            cli.email = cliente.email;
            cli.nombre = cliente.nombre;
            cli.apellido = cliente.apellido;
            cli.empresa = cliente.empresa;
            cli.fechaCreacion = cliente.fechaCreacion;
            cli.pais = cliente.pais;
            this.context.Add(cli);
            this.context.SaveChanges();
        }

        public Cliente BuscarCliente(int idCliente)
        {
            return this.context.Cliente.Where(z => z.Id == idCliente).FirstOrDefault();
        }

        public void ModificarCliente(Cliente cliente)
        {
            Cliente cli = this.BuscarCliente(cliente.Id);
            cli.nombre = cliente.nombre;
            cli.apellido = cliente.apellido;
            cli.empresa= cliente.empresa;
            cli.fechaCreacion= cliente.fechaCreacion;
            cli.pais= cliente.pais;
           
            this.context.SaveChanges();
        }

        public void EliminarCliente(int idCliente)
        {
            Cliente cliente= this.BuscarCliente(idCliente);
            this.context.Cliente.Remove(cliente);
            this.context.SaveChanges();
        }



    }
}
