using Microsoft.Extensions.Configuration;// ///
using System;
using System.Collections.Generic;
using System.IO;///
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos_Dapper.Config
{
    public class DataBaseConfiguration
    {
        public static IConfigurationRoot configuration { get; set; }//

        public static string Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())///
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            string _conn = configuration["ConnectionStrings:DefaultConnection"];

            return _conn;
        }
    }
}
