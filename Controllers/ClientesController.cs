﻿using ApiSalesData.Models;
using ApiSalesData.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiSalesData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {


        IRepositoryClientes repo;


        public ClientesController(IRepositoryClientes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            
            return this.repo.GetClientes();
        }

       [HttpPost("CrearCliente")]
        public ActionResult<Cliente> PostCliente(String email, String nombre, String apellido, String empresa, String pais)
        {
            
            this.repo.PostClientes(email, nombre, apellido, empresa, pais);
            return Ok();
        }

        [HttpPut("ModificarCliente/{idCliente}")]
        public ActionResult<Cliente> Modificar(int idCliente, String email, String nombre, String apellido, String empresa, String fechaCreacion, String pais)
        {

            this.repo.ModificarCliente(idCliente, email, nombre, apellido, empresa, fechaCreacion, pais );
            return Ok();
        }

        [HttpDelete("EliminarCliente/{idCliente}")]
        public ActionResult<Cliente> EliminarCliente(int idCliente)
        {
            this.repo.EliminarCliente(idCliente);
            return Ok();
        }

    }
}
