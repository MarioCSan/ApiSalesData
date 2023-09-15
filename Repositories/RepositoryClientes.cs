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

       
        public void PostClientes(String email, string nombre, string apellido, string empresa, string pais)
        {
            DateTime fecha = DateTime.Now;

            string fechaEnFormatoISO8601 = fecha.ToString("o");

            DateTime fechaCreacion = DateTime.Parse(fechaEnFormatoISO8601, null, System.Globalization.DateTimeStyles.RoundtripKind);

            var consulta = from datos in this.context.Cliente
                           select datos.IdCliente;


            int maxId;
            if (consulta.Max() == 0)
            {
                maxId =  1;
            } else
            {
                maxId = consulta.Max();
            }

            Cliente cli = new Cliente();
            cli.IdCliente = maxId + 1;
            cli.email = email;
            cli.nombre = nombre;
            cli.apellido = apellido;
            cli.empresa = empresa;
            cli.fechaCreacion = fechaCreacion;
            cli.pais = pais;
            this.context.Add(cli);
            this.context.SaveChanges();
        }

        public Cliente BuscarCliente(int idCliente)
        {
            return this.context.Cliente.Where(z => z.IdCliente == idCliente).FirstOrDefault();
        }

        public void ModificarCliente(int idCliente,Cliente cliente)
        {
            Cliente cli = this.BuscarCliente(idCliente);
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
