using ApiSalesData.Models;
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


        IRepositoryCliente repo;

        public ClientesController(RepositoryClientes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            String jsonusuario = claims.SingleOrDefault(x => x.Type == "Cliente").Value;

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(jsonusuario);
            return this.repo.GetClientes();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Cliente> PostCliente(Cliente Cliente)
        {
            
            this.repo.PostClientes(Cliente);
            return RedirectToAction("GetTransaccionesUsuario");
        }

        [HttpPut]
        [Route("[action]/{idtransaccion}")]
        public ActionResult<Cliente> Modificar(Cliente cliente)
        {

            this.repo.ModificarCliente(cliente);
            return RedirectToAction("GetClientes");
        }

        [HttpDelete]
        [Route("[action]/{idCliente}")]
        public ActionResult<Cliente> EliminarCliente(int idCliente)
        {
            this.repo.EliminarCliente(idCliente);
            return RedirectToAction("GetClientes");
        }

    }
}
