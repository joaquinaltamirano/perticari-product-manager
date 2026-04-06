using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        #region ===== ESTADO =====
        string textoBusqueda = "";
        Dictionary<string, int> nivelesFiltro = new();
        List<Producto> productos = new();
        Filtros filtros = new();
        Nodo raiz;
        int yOffset = 0;

        private const string PlaceholderBusqueda = "Escribí el nombre de un producto...";
        #endregion

        #region ===== UI CONFIG =====
        Color verdeOsc = Color.FromArgb(15, 30, 19);
        Color verdeCla = Color.FromArgb(162, 233, 191);
        Color bordeGris = Color.FromArgb(210, 210, 210);
        Color fondo = Color.FromArgb(239, 248, 244);
        #endregion

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            timerHora.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = verdeCla;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = verdeOsc;

            dataGridView1.BackgroundColor = fondo;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 230);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            GenerarMockProductos();
            raiz = MapaCategorias.Crear();

            RefrescarTodo();
        }

        #region ===== RENDER PRINCIPAL =====

        void RefrescarTodo()
        {
            ResetUI();

            panelContenedor.SuspendLayout();
            panelContenedor.Controls.Clear();

            RenderSeccion(raiz, 0);
            ConstruirCascada(raiz, 0);

            AplicarFiltros();
            RenderFiltrosActivos();
            ActualizarBreadcrumb();

            panelContenedor.ResumeLayout();
        }

        void ConstruirCascada(Nodo nodoActual, int nivel)
        {
            if (!filtros.Activos.ContainsKey(nodoActual.ClaveFiltro))
                return;

            string valor = filtros.Activos[nodoActual.ClaveFiltro];

            var opcion = nodoActual.Opciones
                .FirstOrDefault(o => o.Nombre == valor);

            if (opcion?.Siguiente != null)
            {
                RenderSeccion(opcion.Siguiente, nivel + 1);
                ConstruirCascada(opcion.Siguiente, nivel + 1);
            }
        }

        #endregion

        #region ===== UI BLOQUES =====

        void RenderSeccion(Nodo nodo, int nivel)
        {
            var bloque = CrearBloque(nodo, nivel);

            bloque.Width = panelContenedor.ClientSize.Width
                           - panelContenedor.Padding.Left
                           - panelContenedor.Padding.Right;

            bloque.Location = new Point(0, yOffset);

            panelContenedor.Controls.Add(bloque);

            yOffset += bloque.Height + 8;

            panelContenedor.BeginInvoke(new Action(() =>
                panelContenedor.ScrollControlIntoView(bloque)));
        }
        void EjecutarFiltro(string texto, int nivel, string clave)
        {
            LimpiarNivelesDesde(nivel);

            filtros.Activos[clave] = texto;
            nivelesFiltro[clave] = nivel;

            RefrescarTodo();
        }

        System.Windows.Forms.Panel CrearBloque(Nodo nodo, int nivel)
        {
            int columnas = 3;
            int filas = (int)Math.Ceiling(nodo.Opciones.Count / (double)columnas);

            int headerH = 50;
            int rowH = 55;
            int paddingBottom = 10;

            int alturaTotal = headerH + (filas * rowH) + paddingBottom;

            var bloque = new System.Windows.Forms.Panel
            {
                Height = alturaTotal,
                BackColor = Color.Transparent,
                Padding = new Padding(15, 60, 15, 10),
                Margin = new Padding(0),
                Tag = nivel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            if (nivel == 0)
                bloque.Paint += PintarGradiente;

            var titulo = CrearTitulo(nodo.Titulo, nivel);
            var grid = CrearGridOpciones(nodo, nivel, filas);

            bloque.Controls.Add(grid);
            bloque.Controls.Add(titulo);

            titulo.BringToFront();

            return bloque;
        }

        void PintarGradiente(object sender, PaintEventArgs e)
        {
            var panel = (System.Windows.Forms.Panel)sender;

            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(119, 216, 158), // top
                Color.FromArgb(239, 248, 244), // bottom
                90f); // vertical

            e.Graphics.FillRectangle(brush, panel.ClientRectangle);
        }

        TableLayoutPanel CrearGridOpciones(Nodo nodo, int nivel, int filas)
        {
            int columnas = 3;

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = false,
                ColumnCount = columnas,
                RowCount = filas,
                Height = filas * 55,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 5, 0, 0)
            };

            // columnas iguales
            grid.ColumnStyles.Clear();
            for (int i = 0; i < columnas; i++)
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            // filas fijas
            grid.RowStyles.Clear();
            for (int i = 0; i < filas; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));

            int index = 0;

            foreach (var op in nodo.Opciones)
            {
                var btn = CrearBoton(op.Nombre, nivel, nodo.ClaveFiltro, index + 1);
                btn.Dock = DockStyle.Fill;

                int col = index % columnas;
                int row = index / columnas;

                grid.Controls.Add(btn, col, row);
                index++;
            }

            return grid;
        }

        Label CrearTitulo(string texto, int nivel)
        {
            return new Label
            {
                Text = texto.ToUpper(),
                Font = new Font("Nexa Heavy", 10, FontStyle.Bold),
                ForeColor = (nivel == 0) ? Color.White : verdeOsc,
                BackColor = (nivel == 0) ? verdeOsc : verdeCla,
                Size = new Size(130, 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15)
            };
        }

        Control CrearBoton(string texto, int nivel, string clave, int indice)
        {
            bool seleccionado =
                filtros.Activos.ContainsKey(clave) &&
                filtros.Activos[clave] == texto;

            var btn = new FoxButton
            {
                Text = texto.ToUpper(),
                Font = new Font("Nexa Heavy", 8),
                Height = 45,
                BaseColor = seleccionado ? verdeOsc : Color.White,
                ForeColor = seleccionado ? Color.White : verdeOsc,
                BorderColor = bordeGris,
                Cursor = Cursors.Hand,
                Margin = new Padding(8),
                Dock = DockStyle.Fill
            };

            if (seleccionado)
                btn.OverColor = Color.FromArgb(24, 48, 31);

            btn.MouseEnter += (s, e) =>
            {
                if (!seleccionado)
                    btn.BaseColor = Color.FromArgb(245, 245, 245);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BaseColor = seleccionado ? verdeOsc : Color.White;
            };

            btn.Click += (s, e) =>
            {
                EjecutarFiltro(texto, nivel, clave);
            };

            btn.Paint += (s, e) =>
            {
                var g = e.Graphics;

                var rectIndicador = new Rectangle(0, 0, 20, 10);
                Color verdeIndicador = Color.FromArgb(119, 216, 158);

                using (var brushFondo = new SolidBrush(verdeIndicador))
                {
                    g.FillRectangle(brushFondo, rectIndicador);
                }

                using (var fontNumero = new Font("Nexa Heavy", 8, FontStyle.Bold))
                using (var brushVerde = new SolidBrush(verdeOsc))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    g.DrawString(indice.ToString(), fontNumero, brushVerde, rectIndicador, sf);
                }
            };

            btn.Tag = new { texto, nivel, clave, indice };
            return btn;
        }

        void LimpiarNivelesDesde(int nivel)
        {
            var borrar = nivelesFiltro
                .Where(x => x.Value >= nivel)
                .Select(x => x.Key)
                .ToList();

            foreach (var k in borrar)
            {
                filtros.Activos.Remove(k);
                nivelesFiltro.Remove(k);
            }
        }
        void ResetUI()
        {
            panelContenedor.Controls.Clear();
            yOffset = 0;
        }

        #endregion

        #region ===== FILTROS =====

        void AplicarFiltros()
        {
            var filtrados = productos.Where(p =>
                filtros.Activos.All(f =>
                    f.Key == "Categoria"
                        ? p.Categoria.Equals(f.Value, StringComparison.OrdinalIgnoreCase)
                        : p.Atributos.ContainsKey(f.Key)
                            ? p.Atributos[f.Key].Equals(f.Value, StringComparison.OrdinalIgnoreCase)
                            : p.Atributos.Values.Any(v => v.Equals(f.Value, StringComparison.OrdinalIgnoreCase))
                )
                &&
                (string.IsNullOrEmpty(textoBusqueda) ||
                 p.Nombre.ToLower().Contains(textoBusqueda))
            ).ToList();

            dataGridView1.DataSource = filtrados
                .Select(p => new { p.Nombre, p.Categoria, p.Stock, p.Precio })
                .ToList();
        }

        void RenderFiltrosActivos()
        {
            panelFiltros.Controls.Clear();

            foreach (var item in nivelesFiltro.OrderBy(x => x.Value))
            {
                bool root = item.Value == 0;

                var chip = new System.Windows.Forms.Button
                {
                    Text = $"{filtros.Activos[item.Key].ToUpper()}  X",
                    AutoSize = true,
                    BackColor = root ? verdeOsc : verdeCla,
                    ForeColor = root ? Color.White : verdeOsc,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Nexa Heavy", 8),
                    Margin = new Padding(4)
                };

                chip.FlatAppearance.BorderSize = 0;

                chip.Click += (s, e) =>
                {
                    LimpiarNivelesDesde(item.Value);
                    RefrescarTodo();
                };

                panelFiltros.Controls.Add(chip);
            }
        }

        void ActualizarBreadcrumb()
        {
            var ruta = nivelesFiltro
                .OrderBy(x => x.Value)
                .Select(x => filtros.Activos[x.Key]);

            labelBreadcrumb.Text =
                ruta.Any() ? string.Join(" > ", ruta) : "Todos los productos";
        }

        #endregion

        #region ===== BUSCADOR =====

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == PlaceholderBusqueda)
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = verdeOsc;
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = PlaceholderBusqueda;
                txtBusqueda.ForeColor = Color.DarkGray;
                textoBusqueda = "";
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != PlaceholderBusqueda)
            {
                textoBusqueda = txtBusqueda.Text.ToLower();
                AplicarFiltros(); // Tu método que ya hace el Where(...)
            }
        }

        #endregion
        #region ===== INTERACCION TECLADO =====

        void SimularClickPorIndice(int nro)
        {
            var ultimoBloque = panelContenedor.Controls
                .OfType<System.Windows.Forms.Panel>()
                .LastOrDefault();

            if (ultimoBloque != null)
            {
                var grid = ultimoBloque.Controls
                    .OfType<TableLayoutPanel>()
                    .FirstOrDefault();

                var boton = grid?.Controls
                    .OfType<FoxButton>()
                    .FirstOrDefault(b => b.Tag != null && ((dynamic)b.Tag).indice == nro);

                if (boton != null)
                {
                    var data = (dynamic)boton.Tag;

                    EjecutarFiltro(data.texto, data.nivel, data.clave);
                }
            }
        }
        void RetrocederFiltro()
        {
            if (!nivelesFiltro.Any()) return;

            int maxNivel = nivelesFiltro.Values.Max();

            // eliminar claves del nivel actual
            var clavesEnNivel = nivelesFiltro
                .Where(kv => kv.Value == maxNivel)
                .Select(kv => kv.Key)
                .ToList();

            foreach (var clave in clavesEnNivel)
            {
                nivelesFiltro.Remove(clave);
                filtros.Activos.Remove(clave);
            }

            if (!nivelesFiltro.Any())
            {
                RefrescarTodo();
                return;
            }

            int nuevoMaxNivel = nivelesFiltro.Values.Max();

            LimpiarNivelesDesde(nuevoMaxNivel + 1); 
            RefrescarTodo();
        }

        #endregion

        #region ===== MOCK =====

        void GenerarMockProductos()
        {
            productos = new List<Producto>
    {
        // --- PERFILES ---
        new Producto {
            Nombre="PERFIL ANGULO LAMINADO 1 x 1/8", Categoria="Perfiles", Precio=4500, Stock=50,
            Atributos=new Dictionary<string,string> {{"Tipo","Estructural"}, {"Forma","Angulo"}}
        },
        new Producto {
            Nombre="PERFIL UPN 100 ACINDAR X 12M", Categoria="Perfiles", Precio=85000, Stock=10,
            Atributos=new Dictionary<string,string> {{"Tipo","Estructural"}, {"Forma","UPN"}}
        },
        new Producto {
            Nombre="PERFIL C 100X50X15 GALVANIZADO", Categoria="Perfiles", Precio=28000, Stock=25,
            Atributos=new Dictionary<string,string> {{"Tipo","Livianos"}, {"Perfil","CE"}, {"Acabado","Galvanizado"}}
        },
        new Producto {
            Nombre="PLANCHUELA PERF. REDONDA 1 1/4 X 3/16", Categoria="Perfiles", Precio=9200, Stock=15,
            Atributos=new Dictionary<string,string> {{"Tipo","Macizos"}, {"Forma","Planchuela"}, {"Subtipo","Perforada Redonda"}}
        },

        // --- CHAPAS ---
        new Producto {
            Nombre="CHAPA LISA GALVANIZADA C-25 1x2", Categoria="Chapas", Precio=19500, Stock=40,
            Atributos=new Dictionary<string,string> {{"Tipo","Industriales"}, {"Subtipo","Lisas"}, {"Acabado","Galvanizada"}}
        },
        new Producto {
            Nombre="CHAPA TRAPEZOIDAL T90 CINCALUM C-25", Categoria="Chapas", Precio=14200, Stock=60,
            Atributos=new Dictionary<string,string> {{"Tipo","Techo"}, {"Forma","Trapezoidal"}, {"Material","Cincalum"}}
        },
        new Producto {
            Nombre="CHAPA SINUSOIDAL PREPINTADA NEGRA C-25", Categoria="Chapas", Precio=17800, Stock=20,
            Atributos=new Dictionary<string,string> {{"Tipo","Techo"}, {"Forma","Sinusoidal"}, {"Material","Prepintada"}}
        },

        // --- CAÑOS ---
        new Producto {
            Nombre="CAÑO EPOXI 1/2 SIGAS GAS", Categoria="Caños", Precio=11000, Stock=35,
            Atributos=new Dictionary<string,string> {{"Tipo","Conduccion"}, {"Variante","Epoxi"}}
        },
        new Producto {
            Nombre="CAÑO ESTRUCTURAL CUADRADO 20X20 1.2MM", Categoria="Caños", Precio=6500, Stock=100,
            Atributos=new Dictionary<string,string> {{"Tipo","Estructural"}, {"Forma","Cuadrado"}}
        },
        new Producto {
            Nombre="CAÑO RECTANGULAR 60X40 1.6MM", Categoria="Caños", Precio=12400, Stock=45,
            Atributos=new Dictionary<string,string> {{"Tipo","Estructural"}, {"Forma","Rectangular"}}
        },

        // --- OBRA ---
        new Producto {
            Nombre="HIERRO ALETADO 10MM X 12M", Categoria="Obra", Precio=7800, Stock=150,
            Atributos=new Dictionary<string,string> {{"Tipo","Aletado"}}
        },
        new Producto {
            Nombre="MALLA SIMA 15X15 5.5MM 2X3M", Categoria="Obra", Precio=22000, Stock=30,
            Atributos=new Dictionary<string,string> {{"Tipo","Malla Electrosoldada"}, {"Acabado","Negra"}}
        },
        new Producto {
            Nombre="ALAMBRE RECOCIDO N16 (POR KG)", Categoria="Obra", Precio=2500, Stock=200,
            Atributos=new Dictionary<string,string> {{"Tipo","Alambre"}, {"Subtipo","Recocido"}}
        },

        // --- HYS (Herrajes y Suministros) ---
        new Producto {
            Nombre="ELECTRODOS CONARCO 6013 2.5MM X 1KG", Categoria="HYS", Precio=8900, Stock=80,
            Atributos=new Dictionary<string,string> {{"Tipo","Electrodos"}, {"Marca","Conarco"}}
        },
        new Producto {
            Nombre="RUEDA PORTON CORREDIZO 60MM V", Categoria="HYS", Precio=5200, Stock=40,
            Atributos=new Dictionary<string,string> {{"Tipo","Portones"}, {"Subtipo","Ruedas"}}
        },
        new Producto {
            Nombre="CERRADURA KALLAY 4000 REFORZADA", Categoria="HYS", Precio=15600, Stock=12,
            Atributos=new Dictionary<string,string> {{"Tipo","Herrajes"}, {"Subtipo","Cerraduras"}}
        }
    };
        }

        #endregion

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void limpiarFiltros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Limpiar diccionarios
            filtros.Activos.Clear();
            nivelesFiltro.Clear();

            // 2. Limpiar buscador
            border_txtBusqueda.Text = "Escribí el nombre de un producto...";
            border_txtBusqueda.ForeColor = Color.Gray;
            textoBusqueda = "";

            // 3. Renderizar todo de nuevo
            RefrescarTodo();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBusqueda.Focused) return;

            // --- LÓGICA DE SELECCIÓN (1-9) ---
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9)
            {
                // Convierte la tecla a un número (1, 2, 3...)
                int numeroApretado = (e.KeyCode >= Keys.NumPad1) ? e.KeyCode - Keys.NumPad1 + 1 : e.KeyCode - Keys.D1 + 1;

                SimularClickPorIndice(numeroApretado);
            }

            // --- LÓGICA DE RETROCESO (Borrar último filtro) ---
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.Escape)
            {
                RetrocederFiltro();
            }
        }
    }
}