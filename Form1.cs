namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // =========================
        // 📦 DATOS PRINCIPALES
        // =========================
        List<Producto> productos = new List<Producto>();
        Filtros filtros = new Filtros();
        Nodo raiz;

        public Form1()
        {
            InitializeComponent();
        }

        // =========================
        // 🌳 CREAR BLOQUE DESDE NODO (ENTRY POINT)
        // =========================
        void CrearBloqueDesdeNodo(Nodo nodo, int nivel)
        {
            var bloque = CrearBloqueUI(nodo, nivel);
            panel3.Controls.Add(bloque);

            // 👇 opcional: auto scroll al nuevo bloque
            panel3.ScrollControlIntoView(bloque);
        }

        // =========================
        // 🧱 CREACIÓN VISUAL DEL BLOQUE
        // =========================
        Panel CrearBloqueUI(Nodo nodo, int nivel)
        {
            Panel bloque = new Panel();
            bloque.Width = 300;
            bloque.Height = 150;
            bloque.Margin = new Padding(10);
            bloque.BorderStyle = BorderStyle.FixedSingle;
            bloque.BackColor = Color.LightGray;

            // 🔤 TÍTULO
            Label lbl = new Label();
            lbl.Text = nodo.Titulo;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 30;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // 🔘 CONTENEDOR DE BOTONES
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;

            // 🔁 CREAR BOTONES DINÁMICOS
            foreach (var opcionNodo in nodo.Opciones)
            {
                Button btn = new Button();
                btn.Text = opcionNodo.Nombre;
                btn.Width = 90;
                btn.Height = 35;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;

                btn.Click += (s, e) =>
                {
                    // 🧠 1. guardar filtro
                    filtros.Activos[nodo.ClaveFiltro] = opcionNodo.Nombre;

                    // 🧹 2. borrar lo que está abajo
                    EliminarBloquesDesde(nivel + 1);

                    // 🌱 3. crear siguiente nivel si existe
                    if (opcionNodo.Siguiente != null)
                    {
                        CrearBloqueDesdeNodo(opcionNodo.Siguiente, nivel + 1);
                    }

                    // 🔄 4. actualizar grid
                    AplicarFiltros();
                };

                flow.Controls.Add(btn);
            }

            bloque.Controls.Add(flow);
            bloque.Controls.Add(lbl);

            // 🏷️ guardamos nivel
            bloque.Tag = nivel;

            return bloque;
        }

        // =========================
        // 🧹 BORRAR BLOQUES INFERIORES
        // =========================
        void EliminarBloquesDesde(int nivel)
        {
            var bloquesAEliminar = panel3.Controls
                .Cast<Control>()
                .Where(c => c.Tag != null && (int)c.Tag >= nivel)
                .ToList();

            foreach (var b in bloquesAEliminar)
            {
                panel3.Controls.Remove(b);
            }
        }

        // =========================
        // 📊 GRID
        // =========================
        void CargarGrid(List<Producto> lista)
        {
            dataGridView1.Rows.Clear();

            foreach (var p in lista)
            {
                dataGridView1.Rows.Add(p.Nombre);
            }
        }

        // =========================
        // 🔍 FILTRADO
        // =========================
        void AplicarFiltros()
        {
            var filtrados = productos.Where(p =>
                filtros.Activos.All(f =>
                    (f.Key == "Categoria" && p.Categoria == f.Value) ||
                    (p.Atributos.ContainsKey(f.Key) && p.Atributos[f.Key] == f.Value)
                )
            ).ToList();

            CargarGrid(filtrados);
        }

        // =========================
        // 🚀 INICIO
        // =========================
        private void Form1_Load(object sender, EventArgs e)
        {
            // 🧱 columnas
            dataGridView1.Columns.Add("Nombre", "Nombre");

            // =========================
            // 🧪 DATA MOCK
            // =========================
            productos.Add(new Producto
            {
                Nombre = "Chapa trapezoidal 0.5",
                Categoria = "Chapas",
                Atributos = new Dictionary<string, string>
                {
                    { "Tipo", "Techo" },
                    { "Forma", "Trapezoidal" },
                    { "Espesor", "0.5" }
                }
            });

            productos.Add(new Producto
            {
                Nombre = "Caño 30x30 1.6",
                Categoria = "Caños",
                Atributos = new Dictionary<string, string>
                {
                    { "Tipo", "Estructural" },
                    { "Forma", "Cuadrado" }
                }
            });

            // =========================
            // 🌳 ÁRBOL (SOLO CHAPAS POR AHORA)
            // =========================
            raiz = new Nodo
            {
                Titulo = "PRODUCTO",
                ClaveFiltro = "Categoria",
                Opciones = new List<Opcion>
                {
                    new Opcion
                    {
                        Nombre = "Chapas",
                        Siguiente = new Nodo
                        {
                            Titulo = "TIPO",
                            ClaveFiltro = "Tipo",
                            Opciones = new List<Opcion>
                            {
                                new Opcion
                                {
                                    Nombre = "Techo",
                                    Siguiente = new Nodo
                                    {
                                        Titulo = "FORMA",
                                        ClaveFiltro = "Forma",
                                        Opciones = new List<Opcion>
                                        {
                                            new Opcion { Nombre = "Trapezoidal" },
                                            new Opcion { Nombre = "Sinusoidal" }
                                        }
                                    }
                                },
                                new Opcion { Nombre = "Industriales" }
                            }
                        }
                    },
                    new Opcion { Nombre = "Caños" },
                    new Opcion { Nombre = "Perfiles" }
                }
            };

            // =========================
            // 🟢 ARRANQUE UI
            // =========================
            CrearBloqueDesdeNodo(raiz, 0);

            // cargar todo al inicio
            CargarGrid(productos);
        }
    }
}