namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<Producto> productos = new List<Producto>();
        Filtros filtros = new Filtros();
        public Form1()
        {
            InitializeComponent();
        }

        Panel CrearBloque(string titulo, List<string> opciones, string claveFiltro, int nivel)
        {
            Panel bloque = new Panel();
            bloque.Width = 300;
            bloque.Height = 150;
            bloque.Margin = new Padding(10);

            // 👇 ESTÉTICA (lo que pediste)
            bloque.BorderStyle = BorderStyle.FixedSingle;
            bloque.BackColor = Color.White;

            Label lbl = new Label();
            lbl.Text = titulo;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 30;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;

            foreach (var opcion in opciones)
            {
                Button btn = new Button();
                btn.Text = opcion;
                btn.Width = 90;
                btn.Height = 35;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;

                btn.Click += (s, e) =>
                {
                    // 1. guardar filtro
                    filtros.Activos[claveFiltro] = opcion;

                    // 2. borrar bloques siguientes
                    EliminarBloquesDesde(nivel + 1);

                    // 3. crear siguiente bloque (hardcodeado por ahora)
                    CrearSiguienteBloque(claveFiltro, opcion, nivel + 1);

                    // 4. actualizar grid
                    AplicarFiltros();
                };

                flow.Controls.Add(btn);
            }

            bloque.Controls.Add(flow);
            bloque.Controls.Add(lbl);

            // 👇 GUARDAMOS NIVEL EN TAG
            bloque.Tag = nivel;

            return bloque;
        }

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

        void CrearSiguienteBloque(string clave, string valor, int nivel)
        {
            // ejemplo básico
            if (clave == "Categoria" && valor == "Chapas")
            {
                var opciones = new List<string> { "Industriales", "Techo" };

                var bloque = CrearBloque("TIPO", opciones, "Tipo", nivel);
                panel3.Controls.Add(bloque);
                panel3.ScrollControlIntoView(bloque);
            }

            if (clave == "Tipo" && valor == "Techo")
            {
                var opciones = new List<string> { "Trapezoidal", "Sinusoidal" };

                var bloque = CrearBloque("FORMA", opciones, "Forma", nivel);
                panel3.Controls.Add(bloque);
                panel3.ScrollControlIntoView(bloque);
            }
        }
        void CargarGrid(List<Producto> lista)
        {
            dataGridView1.Rows.Clear();

            foreach (var p in lista)
            {
                dataGridView1.Rows.Add(p.Nombre);
            }
        }

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
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Nombre", "Nombre");
            productos.Add(new Producto
            {
                Nombre = "Caño 30x30 1.6",
                Categoria = "Caños",
                Atributos = new Dictionary<string, string>
    {
        { "Tipo", "Estructural" },
        { "Forma", "Cuadrado" },
        { "Medida", "30x30" },
        { "Espesor", "1.6" }
    }
            });

            productos.Add(new Producto
            {
                Nombre = "Caño 40x40 2.0",
                Categoria = "Caños",
                Atributos = new Dictionary<string, string>
    {
        { "Tipo", "Estructural" },
        { "Forma", "Cuadrado" },
        { "Medida", "40x40" },
        { "Espesor", "2.0" }
    }
            });

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
            CargarGrid(productos);

            var opciones = new List<string> { "Caños", "Chapas", "Perfiles" };

            var bloque = CrearBloque("PRODUCTO", opciones, "Categoria", 0);
            panel3.Controls.Add(bloque);
        }
    }
}
