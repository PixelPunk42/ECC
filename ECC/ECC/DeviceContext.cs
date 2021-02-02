using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECC
{
    /// <summary>
    /// DbContext for the data model. The database will be created in bin\Debug\netcoreapp3.1 if not present.
    /// </summary>
    class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Eppendorf.db");
        }
    }
}
