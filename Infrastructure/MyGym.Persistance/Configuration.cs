using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Persistance
{
    static class Configuration
    {
        public static string ConnectionString {
            get
            {
                ConfigurationManager conf = new();
                conf.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/MyGym.API"));
                conf.AddJsonFile("appsettings.json");
                return conf.GetConnectionString("PostgreSQL");
            }
        }
    }
}
