using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Model
{
    /// <summary>
    /// 
    /// Esta es la clase modelo,
    /// Contiene la información de los objetos "Car"
    /// 
    /// </summary>
    /// 
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public int Doors { get; set; }

    }
}
