using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierreAuthen.Models
{
    public class PierreAuthenContextFactory : IDesignTimeDbContextFactory<PierreAuthenContext>
    {

        PierreAuthenContext IDesignTimeDbContextFactory<PierreAuthenContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PierreAuthenContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new PierreAuthenContext(builder.Options);
        }
    }
}
