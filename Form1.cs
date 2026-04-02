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
        // =========================
        // 🔍 ESTADO Y BUSCADOR
        // =========================
        string textoBusqueda = "";
        Dictionary<string, int> nivelesFiltro = new Dictionary<string, int>();

        // =========================
        // 📦 MODELOS DE DATOS
        // =========================
        List<Producto> productos = new List<Producto>();
        Filtros filtros = new Filtros();
        Nodo raiz;

        public Form1()
        {
            InitializeComponent();
        }

        // =========================
        // 🌳 MOTOR DE INTERFAZ (Recursivo)
        // =========================
        void RefrescarTodo()
        {
            // 1. Limpiar el contenedor de bloques visuales
            panel3.Controls.Clear();

            // 2. Reconstruir la cascada de paneles basándose en la jerarquía activa
            ReconstruirCascada(raiz, 0);

            // 3. Sincronizar datos y elementos de apoyo
            AplicarFiltros();
            RenderFiltrosActivos();
            ActualizarBreadcrumb();
        }

        void ReconstruirCascada(Nodo nodoActual, int nivel)
        {
            if (nodoActual == null) return;

            // Crear y agregar el bloque de opciones al panel
            var bloque = CrearBloqueUI(nodoActual, nivel);
            panel3.Controls.Add(bloque);
            panel3.ScrollControlIntoView(bloque);

            // Si este nodo tiene un filtro seleccionado, "viajamos" al siguiente nivel
            if (filtros.Activos.ContainsKey(nodoActual.ClaveFiltro))
            {
                string valorSeleccionado = filtros.Activos[nodoActual.ClaveFiltro];
                var opcion = nodoActual.Opciones.FirstOrDefault(o => o.Nombre == valorSeleccionado);

                if (opcion != null && opcion.Siguiente != null)
                {
                    ReconstruirCascada(opcion.Siguiente, nivel + 1);
                }
            }
        }

        // =========================
        // 🧱 CONSTRUCCIÓN DE BLOQUES (UI Dinámica)
        // =========================
        Panel CrearBloqueUI(Nodo nodo, int nivel)
        {
            Panel bloque = new Panel
            {
                Width = 300,
                Height = 150,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Tag = nivel // El Tag es clave para identificar el nivel en el árbol
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

            FlowLayoutPanel flow = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };

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

                // 🎨 SINCRONIZACIÓN VISUAL: ¿Es la opción seleccionada?
                if (filtros.Activos.ContainsKey(nodo.ClaveFiltro) && filtros.Activos[nodo.ClaveFiltro] == opcionNodo.Nombre)
                {
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }

                btn.Click += (s, e) =>
                {
                    // 1. Al elegir, matamos cualquier filtro que sea de nivel igual o superior (limpieza jerárquica)
                    var clavesAEliminar = nivelesFiltro.Where(x => x.Value >= nivel).Select(x => x.Key).ToList();
                    foreach (var c in clavesAEliminar)
                    {
                        filtros.Activos.Remove(c);
                        nivelesFiltro.Remove(c);
                    }

                    // 2. Registramos la nueva selección
                    filtros.Activos[nodo.ClaveFiltro] = opcionNodo.Nombre;
                    nivelesFiltro[nodo.ClaveFiltro] = nivel;

                    // 3. Gatillamos la reconstrucción total
                    RefrescarTodo();
                };

                flow.Controls.Add(btn);
            }

            bloque.Controls.Add(flow);
            bloque.Controls.Add(lbl);
            return bloque;
        }

        // =========================
        // 🏷️ CHIPS Y BREADCRUMB
        // =========================
        void RenderFiltrosActivos()
        {
            panelFiltros.Controls.Clear();

            // Ordenamos por nivel para que los chips respeten la jerarquía visual
            var filtrosOrdenados = nivelesFiltro.OrderBy(x => x.Value).ToList();

            foreach (var item in filtrosOrdenados)
            {
                Button chip = new Button
                {
                    Text = $"{filtros.Activos[item.Key]} ✕",
                    AutoSize = true,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(2),
                    Cursor = Cursors.Hand
                };

                chip.Click += (s, e) =>
                {
                    // Al borrar un chip, eliminamos esa rama y sus descendientes
                    var aBorrar = nivelesFiltro.Where(x => x.Value >= item.Value).Select(x => x.Key).ToList();
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

        void ActualizarBreadcrumb()
        {
            var ruta = nivelesFiltro.OrderBy(x => x.Value)
                                    .Select(x => filtros.Activos[x.Key]);

            labelBreadcrumb.Text = ruta.Any() ? string.Join(" > ", ruta) : "Todos los productos";
        }

        // =========================
        // 📊 FILTRADO DE DATOS (LINQ)
        // =========================
        void AplicarFiltros()
        {
            var filtrados = productos.Where(p =>
                filtros.Activos.All(f =>
                    (f.Key == "Categoria" && p.Categoria == f.Value) ||
                    (p.Atributos.ContainsKey(f.Key) && p.Atributos[f.Key] == f.Value)
                )
                &&
                (
                    string.IsNullOrEmpty(textoBusqueda) ||
                    p.Nombre.ToLower().Contains(textoBusqueda) ||
                    p.Atributos.Values.Any(v => v != null && v.ToLower().Contains(textoBusqueda))
                )
            ).ToList();

            CargarGrid(filtrados);
        }

        void CargarGrid(List<Producto> lista)
        {
            dataGridView1.Rows.Clear();
            foreach (var p in lista)
            {
                dataGridView1.Rows.Add(p.Nombre);
            }
        }

        // =========================
        // 🚀 EVENTOS DE FORMULARIO
        // =========================
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Nombre", "Nombre");

            // Mock Data para pruebas
            productos.Add(new Producto { Nombre = "Chapa trapezoidal 0.5", Categoria = "Chapas", Atributos = new Dictionary<string, string> { { "Tipo", "Techo" }, { "Forma", "Trapezoidal" } } });
            productos.Add(new Producto { Nombre = "Caño 30x30 1.6", Categoria = "Caños", Atributos = new Dictionary<string, string> { { "Tipo", "Estructural" }, { "Forma", "Cuadrado" } } });

            raiz = MapaCategorias.Crear();
            RefrescarTodo();

            textBox1.TextChanged += (s, ev) =>
            {
                textoBusqueda = textBox1.Text.ToLower();
                AplicarFiltros();
            };
        }

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