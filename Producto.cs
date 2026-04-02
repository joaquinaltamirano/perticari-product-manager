using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }

        public Dictionary<string, string> Atributos { get; set; } = new();
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
