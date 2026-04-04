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
        #endregion

        #region ===== UI CONFIG =====
        Color verdeOsc = Color.FromArgb(15, 30, 19);
        Color verdeCla = Color.FromArgb(162, 233, 191);
        Color bordeGris = Color.FromArgb(210, 210, 210);
        #endregion

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = verdeCla;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = verdeOsc;

            dataGridView1.BackgroundColor = Color.White;
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

        #region ===== UI BLOQUES (FIXED PANEL STACK) =====

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
                var btn = CrearBoton(op.Nombre, nivel, nodo.ClaveFiltro);
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

        Control CrearBoton(string texto, int nivel, string clave)
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
                LimpiarNivelesDesde(nivel);

                filtros.Activos[clave] = texto;
                nivelesFiltro[clave] = nivel;

                RefrescarTodo();
            };

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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Escribí el nombre de un producto...")
                textoBusqueda = "";
            else
                textoBusqueda = txtBusqueda.Text.ToLower();

            AplicarFiltros();
        }

        #endregion

        #region ===== MOCK =====

        void GenerarMockProductos()
        {
            productos = new List<Producto>
            {
                new Producto
                {
                    Nombre="Chapa T101",
                    Categoria="Chapas",
                    Precio=1200,
                    Stock=20,
                    Atributos=new Dictionary<string,string>
                    {
                        {"Tipo","Techo"},
                        {"Forma","Trapezoidal"}
                    }
                },
                new Producto
                {
                    Nombre="Caño 30x30",
                    Categoria="Caños",
                    Precio=800,
                    Stock=50,
                    Atributos=new Dictionary<string,string>
                    {
                        {"Tipo","Estructural"}
                    }
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
    }
}