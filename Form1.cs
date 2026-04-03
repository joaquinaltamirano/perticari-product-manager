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
        #region ===== CONFIGURACIÓN Y ESTADO =====
        string textoBusqueda = "";
        Dictionary<string, int> nivelesFiltro = new();
        List<Producto> productos = new();
        Filtros filtros = new();
        Nodo raiz;

        // Paleta de colores consistente
        Color verdeOsc = Color.FromArgb(15, 30, 19);
        Color verdeCla = Color.FromArgb(162, 233, 191);
        Color bordeGris = Color.FromArgb(210, 210, 210);
        #endregion

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Configuración del contenedor principal (FlowLayoutPanel)
            panelContenedor.AutoScroll = true;
            panelContenedor.FlowDirection = FlowDirection.TopDown;
            panelContenedor.WrapContents = false;
            panelContenedor.HorizontalScroll.Enabled = false;
            panelContenedor.HorizontalScroll.Visible = false;
            panelContenedor.HorizontalScroll.Maximum = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerarMockProductos();
            raiz = MapaCategorias.Crear();
            RefrescarTodo();
        }

        #region ===== MOTOR DE RENDERIZADO (SCROLL ÚNICO) =====

        void RefrescarTodo()
        {
            panelContenedor.SuspendLayout();
            panelContenedor.Controls.Clear();
            panelContenedor.AutoScrollPosition = new Point(0, 0);

            // Renderizado inicial y cascada recursiva
            RenderSeccion(raiz, 0);
            ConstruirCascada(raiz, 0);

            AplicarFiltros();
            RenderFiltrosActivos();
            ActualizarBreadcrumb();

            panelContenedor.ResumeLayout();
        }

        void ConstruirCascada(Nodo nodoActual, int nivel)
        {
            if (filtros.Activos.ContainsKey(nodoActual.ClaveFiltro))
            {
                string valorSeleccionado = filtros.Activos[nodoActual.ClaveFiltro];
                var opcion = nodoActual.Opciones.FirstOrDefault(o => o.Nombre == valorSeleccionado);

                if (opcion?.Siguiente != null)
                {
                    RenderSeccion(opcion.Siguiente, nivel + 1);
                    ConstruirCascada(opcion.Siguiente, nivel + 1);
                }
            }
        }

        void RenderSeccion(Nodo nodo, int nivel)
        {
            int anchoUtil = panelContenedor.ClientSize.Width - 35;
            int anchoMinBoton = 110;

            var bloque = new System.Windows.Forms.Panel
            {
                Width = anchoUtil,
                AutoSize = true,
                Margin = new Padding(0, (nivel == 0 ? 25 : 10), 0, 15),
                BackColor = Color.Transparent
            };

            // Gradiente decorativo solo para el primer nivel (PRODUCTO)
            if (nivel == 0)
            {
                bloque.Paint += (s, e) =>
                {
                    using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        bloque.ClientRectangle, verdeCla, Color.FromArgb(245, 245, 245), 90f))
                    { e.Graphics.FillRectangle(brush, bloque.ClientRectangle); }
                };
            }

            var lbl = new Label
            {
                Text = nodo.Titulo.ToUpper(),
                Font = new Font("Nexa Heavy", 10, FontStyle.Bold),
                ForeColor = (nivel == 0) ? Color.White : verdeOsc,
                BackColor = (nivel == 0) ? verdeOsc : verdeCla,
                Size = new Size(160, 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(15, 10)
            };

            var flow = new FlowLayoutPanel
            {
                Location = new Point(10, 50),
                Width = anchoUtil - 20,
                AutoSize = true,
                WrapContents = true, // Evita scroll horizontal, los botones bajan
                Padding = new Padding(5),
                BackColor = Color.Transparent
            };

            foreach (var op in nodo.Opciones)
                flow.Controls.Add(CrearBotonEstiloFox(op.Nombre, nivel, nodo.ClaveFiltro, flow.Width - 20, anchoMinBoton));

            bloque.Controls.Add(lbl);
            bloque.Controls.Add(flow);
            panelContenedor.Controls.Add(bloque);

            // Auto-scroll suave al nuevo bloque
            this.BeginInvoke(new Action(() => panelContenedor.ScrollControlIntoView(bloque)));
        }

        Control CrearBotonEstiloFox(string texto, int nivel, string clave, int anchoMax, int anchoMin)
        {
            bool seleccionado = filtros.Activos.ContainsKey(clave) && filtros.Activos[clave] == texto;
            Font fuente = new Font("Nexa Heavy", 9);

            // Cálculo de ancho dinámico para no cortar texto
            int anchoRequerido = TextRenderer.MeasureText(texto.ToUpper(), fuente).Width + 25;
            int anchoFinal = Math.Min(Math.Max(anchoMin, anchoRequerido), anchoMax);

            var btn = new FoxButton
            {
                Text = texto.ToUpper(),
                Font = fuente,
                Size = new Size(anchoFinal, 45),
                BaseColor = seleccionado ? verdeOsc : Color.White,
                ForeColor = seleccionado ? Color.White : verdeOsc,
                BorderColor = bordeGris,
                Cursor = Cursors.Hand,
                Margin = new Padding(5)
            };

            btn.MouseEnter += (s, e) => { if (!seleccionado) btn.BaseColor = Color.FromArgb(245, 245, 245); };
            btn.MouseLeave += (s, e) => { btn.BaseColor = seleccionado ? verdeOsc : Color.White; };

            btn.Click += (s, e) =>
            {
                // Limpieza de niveles inferiores al cambiar selección
                var borrar = nivelesFiltro.Where(x => x.Value >= nivel).Select(x => x.Key).ToList();
                foreach (var k in borrar) { filtros.Activos.Remove(k); nivelesFiltro.Remove(k); }

                filtros.Activos[clave] = texto;
                nivelesFiltro[clave] = nivel;
                RefrescarTodo();
            };

            return btn;
        }
        #endregion

        #region ===== LÓGICA DE FILTROS Y BREADCRUMB =====

        void AplicarFiltros()
        {
            var filtrados = productos.Where(p =>
                filtros.Activos.All(f =>
                    f.Key == "Categoria" ? p.Categoria.Equals(f.Value, StringComparison.OrdinalIgnoreCase) :
                    p.Atributos.ContainsKey(f.Key) ? p.Atributos[f.Key].Equals(f.Value, StringComparison.OrdinalIgnoreCase) :
                    p.Atributos.Values.Any(v => v.Equals(f.Value, StringComparison.OrdinalIgnoreCase))
                ) && (string.IsNullOrEmpty(textoBusqueda) || p.Nombre.ToLower().Contains(textoBusqueda.ToLower()))
            ).ToList();

            dataGridView1.DataSource = filtrados.Select(p => new { p.Nombre, p.Categoria, p.Stock, p.Precio }).ToList();
        }

        void RenderFiltrosActivos()
        {
            panelFiltros.Controls.Clear();
            foreach (var item in nivelesFiltro.OrderBy(x => x.Value))
            {
                bool esRoot = item.Value == 0;
                var chip = new System.Windows.Forms.Button
                {
                    Text = $"{filtros.Activos[item.Key].ToUpper()}  X",
                    AutoSize = true,
                    BackColor = esRoot ? verdeOsc : verdeCla,
                    ForeColor = esRoot ? Color.White : verdeOsc,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Nexa Heavy", 8),
                    Margin = new Padding(4)
                };
                chip.FlatAppearance.BorderSize = 0;
                chip.Click += (s, e) =>
                {
                    var borrar = nivelesFiltro.Where(x => x.Value >= item.Value).Select(x => x.Key).ToList();
                    foreach (var k in borrar) { filtros.Activos.Remove(k); nivelesFiltro.Remove(k); }
                    RefrescarTodo();
                };
                panelFiltros.Controls.Add(chip);
            }
        }

        void ActualizarBreadcrumb()
        {
            var ruta = nivelesFiltro.OrderBy(x => x.Value).Select(x => filtros.Activos[x.Key]);
            labelBreadcrumb.Text = ruta.Any() ? string.Join(" > ", ruta) : "Todos los productos";
        }
        #endregion

        #region ===== MOCK DATA Y EVENTOS =====
        void GenerarMockProductos()
        {
            productos = new List<Producto> {
                new Producto { Nombre="Chapa T101", Categoria="Chapas", Precio=1200, Stock=20, Atributos=new Dictionary<string,string>{{"Tipo","Techo"},{"Forma","Trapezoidal"}} },
                new Producto { Nombre="Caño 30x30", Categoria="Caños", Precio=800, Stock=50, Atributos=new Dictionary<string,string>{{"Tipo","Estructural"}} }
            };
        }

        private void limpiarFiltros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            filtros.Activos.Clear();
            nivelesFiltro.Clear();
            txtBusqueda.ResetText();
            RefrescarTodo();
        }

        private void btn_Cerrar_Click_1(object sender, EventArgs e) => this.Close();
        #endregion

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Escribí el nombre de un producto...")
            {
                textoBusqueda = "";
            }
            else
            {
                textoBusqueda = txtBusqueda.Text.ToLower();
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = "Escribí el nombre de un producto...";
                txtBusqueda.ForeColor = Color.Gray;
            }
        }

        private void limpiarFiltros_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            filtros.Activos.Clear();
            nivelesFiltro.Clear();

            // 2. Reseteamos el buscador
            textoBusqueda = "";
            txtBusqueda.Text = "Escribí el nombre de un producto...";
            txtBusqueda.ForeColor = Color.Gray;

            // 3. Reconstruimos la interfaz desde cero
            RefrescarTodo();

            // 4. Opcional: Quitar el foco del link para que se vea limpio
            this.ActiveControl = null;
        }

        private void txtBusqueda_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Escribí el nombre de un producto...")
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = Color.Black;
            }
        }
    }
}