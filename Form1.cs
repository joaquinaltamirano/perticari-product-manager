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

        void CrearBoton(string texto, string claveFiltro, string valor)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Width = 100;
            btn.Height = 40;

            btn.Click += (s, e) =>
            {
                filtros.Activos[claveFiltro] = valor;
                AplicarFiltros();
            };

            flowLayoutPanel1.Controls.Add(btn);
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

            CrearBoton("Caños", "Categoria", "Caños");
            CrearBoton("Chapas", "Categoria", "Chapas");
            CrearBoton("Perfiles", "Categoria", "Perfiles");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filtros.Activos["Categoria"] = "Perfiles";
            AplicarFiltros();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filtros.Activos["Categoria"] = "Caños";
            AplicarFiltros();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filtros.Activos["Categoria"] = "Chapas";
            AplicarFiltros();
        }
    }
}
