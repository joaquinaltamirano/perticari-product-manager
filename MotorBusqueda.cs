using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    class MotorBusqueda
    {
        public List<Producto> Productos { get; set; }
        public Dictionary<string, string> Filtros { get; set; }

        public List<Producto> Filtrar()
        {
            return Productos.Where(p =>
                Filtros.All(f =>
                    (f.Key == "Categoria" && p.Categoria == f.Value) ||
                    (p.Atributos.ContainsKey(f.Key) && p.Atributos[f.Key] == f.Value)
                )
            ).ToList();
        }
    }
}
