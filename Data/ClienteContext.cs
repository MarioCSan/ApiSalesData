using ApiSalesData.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSalesData.Data
{
    public class ClienteContext : DbContext
    {

        public ClienteContext(DbContextOptions<ClienteContext> options): base(options) { }
        public DbSet<Cliente> Cliente { get; set; }


    }
}
