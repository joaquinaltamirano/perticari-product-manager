using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // === ESTADO ===
        string textoBusqueda = "";
        Dictionary<string, int> nivelesFiltro = new Dictionary<string, int>();

        // === DATOS ===
        List<Producto> productos = new List<Producto>();
        Filtros filtros = new Filtros();
        Nodo raiz;

        public Form1()
        {
            InitializeComponent();
        }

        // === REFRESH GENERAL ===
        void RefrescarTodo()
        {
            panel3.Controls.Clear();

            ReconstruirCascada(raiz, 0);

            AplicarFiltros();
            RenderFiltrosActivos();
            ActualizarBreadcrumb();
        }

        // === NAVEGACIÓN DINÁMICA ===
        void ReconstruirCascada(Nodo nodoActual, int nivel)
        {
            if (nodoActual == null) return;

            var bloque = CrearBloqueUI(nodoActual, nivel);
            panel3.Controls.Add(bloque);
            panel3.ScrollControlIntoView(bloque);

            if (filtros.Activos.ContainsKey(nodoActual.ClaveFiltro))
            {
                string valorSeleccionado = filtros.Activos[nodoActual.ClaveFiltro];

                var opcion = nodoActual.Opciones
                    .FirstOrDefault(o => o.Nombre == valorSeleccionado);

                if (opcion != null && opcion.Siguiente != null)
                {
                    ReconstruirCascada(opcion.Siguiente, nivel + 1);
                }
            }
        }

        // === BLOQUES UI ===
        Panel CrearBloqueUI(Nodo nodo, int nivel)
        {
            Panel bloque = new Panel
            {
                Width = 300,
                Height = 150,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Tag = nivel
            };

            Label lbl = new Label
            {
                Text = nodo.Titulo,
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(5)
            };

            foreach (var opcionNodo in nodo.Opciones)
            {
                Button btn = new Button
                {
                    Text = opcionNodo.Nombre,
                    Width = 90,
                    Height = 35,
                    FlatStyle = FlatStyle.Flat
                };

                btn.FlatAppearance.BorderColor = Color.Black;

                bool seleccionado =
                    filtros.Activos.ContainsKey(nodo.ClaveFiltro) &&
                    filtros.Activos[nodo.ClaveFiltro] == opcionNodo.Nombre;

                btn.BackColor = seleccionado ? Color.Black : Color.LightGray;
                btn.ForeColor = seleccionado ? Color.White : Color.Black;

                btn.Click += (s, e) =>
                {
                    var clavesAEliminar = nivelesFiltro
                        .Where(x => x.Value >= nivel)
                        .Select(x => x.Key)
                        .ToList();

                    foreach (var c in clavesAEliminar)
                    {
                        filtros.Activos.Remove(c);
                        nivelesFiltro.Remove(c);
                    }

                    filtros.Activos[nodo.ClaveFiltro] = opcionNodo.Nombre;
                    nivelesFiltro[nodo.ClaveFiltro] = nivel;

                    RefrescarTodo();
                };

                flow.Controls.Add(btn);
            }

            bloque.Controls.Add(flow);
            bloque.Controls.Add(lbl);

            return bloque;
        }

        // === CHIPS ===
        void RenderFiltrosActivos()
        {
            panelFiltros.Controls.Clear();

            var filtrosOrdenados = nivelesFiltro.OrderBy(x => x.Value);

            foreach (var item in filtrosOrdenados)
            {
                Button chip = new Button
                {
                    Text = $"{filtros.Activos[item.Key]} ✕",
                    AutoSize = true,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(2)
                };

                chip.Click += (s, e) =>
                {
                    var aBorrar = nivelesFiltro
                        .Where(x => x.Value >= item.Value)
                        .Select(x => x.Key)
                        .ToList();

                    foreach (var c in aBorrar)
                    {
                        filtros.Activos.Remove(c);
                        nivelesFiltro.Remove(c);
                    }

                    RefrescarTodo();
                };

                panelFiltros.Controls.Add(chip);
            }
        }

        // === BREADCRUMB ===
        void ActualizarBreadcrumb()
        {
            var ruta = nivelesFiltro
                .OrderBy(x => x.Value)
                .Select(x => filtros.Activos[x.Key]);

            labelBreadcrumb.Text =
                ruta.Any() ? string.Join(" > ", ruta) : "Todos los productos";
        }

        // === FILTRADO ===
        // Flexible: matchea por clave o por valor
        void AplicarFiltros()
        {
            var filtrados = productos.Where(p =>
                // 1. Validar que cumpla con TODOS los filtros activos de la jerarquía
                filtros.Activos.All(f =>
                {
                    // Caso A: Es la categoría principal
                    if (f.Key == "Categoria")
                        return p.Categoria.Equals(f.Value, StringComparison.OrdinalIgnoreCase);

                    // Caso B: El producto tiene la clave exacta (ej: "Forma") y el valor coincide
                    if (p.Atributos.ContainsKey(f.Key))
                        return p.Atributos[f.Key].Equals(f.Value, StringComparison.OrdinalIgnoreCase);

                    // Caso C (Salvavidas): Si la clave no matchea, buscamos si el VALOR existe en algún atributo
                    // Esto arregla el problema de si el Nodo se llama "Subtipo" pero el atributo es "Forma"
                    return p.Atributos.Values.Any(v => v.Equals(f.Value, StringComparison.OrdinalIgnoreCase));
                })
                &&
                // 2. Validar el buscador de texto
                (
                    string.IsNullOrEmpty(textoBusqueda) ||
                    p.Nombre.ToLower().Contains(textoBusqueda) ||
                    p.Atributos.Values.Any(v => v != null && v.ToLower().Contains(textoBusqueda))
                )
            ).ToList();

            CargarGrid(filtrados);
        }

        // === GRID ===
        void CargarGrid(List<Producto> lista)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // orden de atributos importante
            List<string> ordenPreferido = new List<string>
    {
        "Tipo",
        "Forma",
        "Perfil",
        "Subtipo",
        "Acabado",
        "Material",
        "Variante",
        "Medida",
        "Espesor"
    };

            var atributos = productos
                .SelectMany(p => p.Atributos.Keys)
                .Distinct()
                .ToList();

            atributos = atributos
                .OrderBy(a =>
                    ordenPreferido.Contains(a)
                    ? ordenPreferido.IndexOf(a)
                    : 999
                )
                .ThenBy(a => a)
                .ToList();

            // columnas base
            dataGridView1.Columns.Add("Nombre", "Producto");
            dataGridView1.Columns.Add("Categoria", "Categoría");

            // atributos
            foreach (var attr in atributos)
            {
                dataGridView1.Columns.Add(attr, attr);
            }

            // 👇 ORDEN FINAL CORRECTO
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Stock", "Stock");

            // filas
            foreach (var p in lista)
            {
                var row = new List<object>
        {
            p.Nombre,
            p.Categoria
        };

                foreach (var attr in atributos)
                {
                    row.Add(p.Atributos.ContainsKey(attr) ? p.Atributos[attr] : "");
                }

                row.Add(p.Precio);
                row.Add(p.Stock);

                dataGridView1.Rows.Add(row.ToArray());
            }

            AjustarColumnas();
        }

        void AjustarColumnas()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name == "Nombre") col.Width = 250;
                else if (col.Name == "Categoria") col.Width = 120;
                else if (col.Name == "Stock") col.Width = 70;
                else if (col.Name == "Precio") col.Width = 90;
                else col.Width = 120;
            }
        }

        // === MOCK DATA ===
        void GenerarMockProductos()
        {
            productos = new List<Producto>
            {
                new Producto {
                    Nombre = "Chapa trapezoidal T101 0.5",
                    Categoria = "Chapas",
                    Precio = 12500,
                    Stock = 50,
                    Atributos = new Dictionary<string,string> {
                        {"Tipo","Techo"},
                        {"Forma","Trapezoidal"},
                        {"Espesor","0.5"},
                        {"Medida","1x3"}
                    }
                },
                new Producto {
                    Nombre = "Chapa sinusoidal 0.4",
                    Categoria = "Chapas",
                    Precio = 9800,
                    Stock = 80,
                    Atributos = new Dictionary<string,string> {
                        {"Tipo","Techo"},
                        {"Forma","Sinusoidal"},
                        {"Espesor","0.4"},
                        {"Medida","1x2.5"}
                    }
                },
                new Producto {
                    Nombre = "Caño estructural 30x30 1.6",
                    Categoria = "Caños",
                    Precio = 7200,
                    Stock = 120,
                    Atributos = new Dictionary<string,string> {
                        {"Tipo","Estructural"},
                        {"Forma","Cuadrado"},
                        {"Espesor","1.6"},
                        {"Medida","30x30"}
                    }
                }
            };

            var random = new Random();
            var baseProductos = productos.ToList();

            for (int i = 0; i < 15; i++)
            {
                var baseP = baseProductos[random.Next(baseProductos.Count)];

                productos.Add(new Producto
                {
                    Nombre = baseP.Nombre + " v" + (i + 1),
                    Categoria = baseP.Categoria,
                    Precio = baseP.Precio + random.Next(-1000, 2000),
                    Stock = random.Next(10, 150),
                    Atributos = new Dictionary<string, string>(baseP.Atributos)
                });
            }
        }

        // === INIT ===
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerarMockProductos();

            raiz = MapaCategorias.Crear();
            RefrescarTodo();

            textBox1.TextChanged += (s, ev) =>
            {
                textoBusqueda = textBox1.Text.ToLower();
                AplicarFiltros();
            };

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowHeadersVisible = false;
        }

        // === RESET ===
        private void limpiarFiltros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            filtros.Activos.Clear();
            nivelesFiltro.Clear();
            textBox1.Clear();
            textoBusqueda = "";

            RefrescarTodo();
        }
    }
}