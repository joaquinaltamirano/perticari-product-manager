using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    internal class Nodo
    {
            public string Titulo { get; set; }
            public string ClaveFiltro { get; set; }
            public List<Opcion> Opciones { get; set; } = new();
        }

        class Opcion
        {
            public string Nombre { get; set; }
            public Nodo Siguiente { get; set; }

            // 👇 NUEVO
            public bool EsFinal { get; set; } = false;
        }
}
