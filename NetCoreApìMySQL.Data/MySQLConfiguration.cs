using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data
{
    public class MySQLConfiguration
    {
        // Esta clase se encarga de la configuración de la base de datos 
        public string _connectionString { get; set; }

        // El constructor (Lambda) pasa la cadena de conexión que recibe a la propiedad que tiene la clase
        public MySQLConfiguration(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
