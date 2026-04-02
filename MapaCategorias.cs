using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp6
{
    internal class MapaCategorias
    {
        public static Nodo Crear()
        {
            return new Nodo
            {
                Titulo = "PRODUCTO",
                ClaveFiltro = "Categoria",
                Opciones = new List<Opcion>
            {
                CrearCanos(),
                CrearChapas(),
                CrearObra(),
                CrearPerfiles(),
                CrearHys()
            }
            };
        }

        static Opcion CrearPerfiles()
        {
            return new Opcion
            {
                Nombre = "Perfiles",
                Siguiente = new Nodo
                {
                    Titulo = "TIPO",
                    ClaveFiltro = "Tipo",
                    Opciones = new List<Opcion>
            {
                // 🟢 ESTRUCTURALES
                new Opcion
                {
                    Nombre = "Estructurales",
                    Siguiente = new Nodo
                    {
                        Titulo = "FORMA",
                        ClaveFiltro = "Forma",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Angulo" },
                            new Opcion { Nombre = "T" },
                            new Opcion { Nombre = "IPN" },
                            new Opcion { Nombre = "UPN" }
                        }
                    }
                },

                // 🟡 LIVIANOS (NUEVO)
                new Opcion
                {
                    Nombre = "Livianos",
                    Siguiente = new Nodo
                    {
                        Titulo = "PERFIL",
                        ClaveFiltro = "Perfil",
                        Opciones = new List<Opcion>
                        {
                            new Opcion
                            {
                                Nombre = "CE",
                                Siguiente = new Nodo
                                {
                                    Titulo = "ACABADO",
                                    ClaveFiltro = "Acabado",
                                    Opciones = new List<Opcion>
                                    {
                                        new Opcion { Nombre = "Negro" },
                                        new Opcion { Nombre = "Galvanizado" }
                                    }
                                }
                            }
                        }
                    }
                },

                // 🔵 MACIZOS
                new Opcion
                {
                    Nombre = "Macizos",
                    Siguiente = new Nodo
                    {
                        Titulo = "FORMA",
                        ClaveFiltro = "Forma",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Redondo" },
                            new Opcion { Nombre = "Cuadrado" },

                            // 🔥 PLANCHUELA MEJORADA
                            new Opcion
                            {
                                Nombre = "Planchuela",
                                Siguiente = new Nodo
                                {
                                    Titulo = "TIPO",
                                    ClaveFiltro = "Subtipo",
                                    Opciones = new List<Opcion>
                                    {
                                        new Opcion { Nombre = "Lisa" },
                                        new Opcion { Nombre = "Perforada Redonda" },
                                        new Opcion { Nombre = "Perforada Cuadrada" }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                }
            };
        }

        static Opcion CrearChapas()
        {
            return new Opcion
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
                    Nombre = "Industriales",
                    Siguiente = new Nodo
                    {
                        Titulo = "SUBTIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion
                            {
                                Nombre = "Lisas",
                                Siguiente = new Nodo
                                {
                                    Titulo = "ACABADO",
                                    ClaveFiltro = "Acabado",
                                    Opciones = new List<Opcion>
                                    {
                                        new Opcion { Nombre = "Gruesa" },
                                        new Opcion { Nombre = "Fina" },
                                        new Opcion { Nombre = "Galvanizada" },
                                        new Opcion { Nombre = "Estampada" },
                                        new Opcion { Nombre = "Perforada" }
                                    }
                                }
                            },
                            new Opcion { Nombre = "Semilladas" }
                        }
                    }
                },
                new Opcion
                {
                    Nombre = "Techo",
                    Siguiente = new Nodo
                    {
                        Titulo = "FORMA",
                        ClaveFiltro = "Forma",
                        Opciones = new List<Opcion>
                        {
                            new Opcion
                            {
                                Nombre = "Sinusoidal",
                                Siguiente = new Nodo
                                {
                                    Titulo = "MATERIAL",
                                    ClaveFiltro = "Material",
                                    Opciones = new List<Opcion>
                                    {
                                        new Opcion { Nombre = "Galvanizado" },
                                        new Opcion { Nombre = "Cincalum" },
                                        new Opcion { Nombre = "Plastica" },
                                        new Opcion { Nombre = "Prepintada" }
                                    }
                                }
                            },
                            new Opcion
                            {
                                Nombre = "Trapezoidal T-101",
                                Siguiente = new Nodo
                                {
                                    Titulo = "MATERIAL",
                                    ClaveFiltro = "Material",
                                    Opciones = new List<Opcion>
                                    {
                                        new Opcion { Nombre = "Galvanizado" },
                                        new Opcion { Nombre = "Cincalum" },
                                        new Opcion { Nombre = "Plastica" },
                                        new Opcion { Nombre = "Prepintada" }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                }
            };
        }

        static Opcion CrearCanos()
        {
            return new Opcion
            {
                Nombre = "Caños",
                Siguiente = new Nodo
                {
                    Titulo = "TIPO",
                    ClaveFiltro = "Tipo",
                    Opciones = new List<Opcion>
            {
                new Opcion
                {
                    Nombre = "Conduccion",
                    Siguiente = new Nodo
                    {
                        Titulo = "VARIANTE",
                        ClaveFiltro = "Variante",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Negro STD" },
                            new Opcion { Nombre = "Uso mecanico" },
                            new Opcion { Nombre = "Galvanizado" },
                            new Opcion { Nombre = "Epoxi" },
                            new Opcion { Nombre = "SCH40" }
                        }
                    }
                },
                new Opcion
                {
                    Nombre = "Estructurales",
                    Siguiente = new Nodo
                    {
                        Titulo = "FORMA",
                        ClaveFiltro = "Forma",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Cuadrado" },
                            new Opcion { Nombre = "Redondo" },
                            new Opcion { Nombre = "Pasamano" },
                            new Opcion { Nombre = "Rectangular" }
                        }
                    }
                }
            }
                }
            };
        }
        static Opcion CrearObra()
        {
            return new Opcion
            {
                Nombre = "Obra",
                Siguiente = new Nodo
                {
                    Titulo = "TIPO",
                    ClaveFiltro = "Tipo",
                    Opciones = new List<Opcion>
            {
                new Opcion { Nombre = "Aletado" },

                new Opcion
                {
                    Nombre = "Malla Electrosoldada",
                    Siguiente = new Nodo
                    {
                        Titulo = "ACABADO",
                        ClaveFiltro = "Acabado",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Negra" },
                            new Opcion { Nombre = "Galvanizada" }
                        }
                    }
                },

                new Opcion
                {
                    Nombre = "Clavos",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Paquete" },
                            new Opcion { Nombre = "Granel" }
                        }
                    }
                },

                new Opcion
                {
                    Nombre = "Alambre",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Recocido" },
                            new Opcion { Nombre = "Ovalado Galvanizado" },
                            new Opcion { Nombre = "Concertina" }
                        }
                    }
                }
            }
                }
            };
        }
        static Opcion CrearHys()
        {
            return new Opcion
            {
                Nombre = "HYS",
                Siguiente = new Nodo
                {
                    Titulo = "CATEGORIA",
                    ClaveFiltro = "Tipo",
                    Opciones = new List<Opcion>
            {
                // ELECTRODOS
                new Opcion
                {
                    Nombre = "Electrodos",
                    Siguiente = new Nodo
                    {
                        Titulo = "MARCA",
                        ClaveFiltro = "Marca",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Acindar" },
                            new Opcion { Nombre = "Conarco" }
                        }
                    }
                },

                // METAL DESPLEGADO
                new Opcion
                {
                    Nombre = "Metal Desplegado",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Expanmetal" },
                            new Opcion { Nombre = "Escalonado" }
                        }
                    }
                },

                // REJAS
                new Opcion
                {
                    Nombre = "Rejas",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Accesorios" },
                            new Opcion { Nombre = "Puntas" }
                        }
                    }
                },

                // PORTONES
                new Opcion
                {
                    Nombre = "Portones",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Ruedas" },
                            new Opcion { Nombre = "Guias" },
                            new Opcion { Nombre = "Rieles" },
                            new Opcion { Nombre = "Carros" },
                            new Opcion { Nombre = "Topes" }
                        }
                    }
                },

                // HERRAJES
                new Opcion
                {
                    Nombre = "Herrajes",
                    Siguiente = new Nodo
                    {
                        Titulo = "TIPO",
                        ClaveFiltro = "Subtipo",
                        Opciones = new List<Opcion>
                        {
                            new Opcion { Nombre = "Bisagras" },
                            new Opcion { Nombre = "Cerraduras" },
                            new Opcion { Nombre = "Candados" },
                            new Opcion { Nombre = "Pernos" },
                            new Opcion { Nombre = "Pasadores" }
                        }
                    }
                }
            }
                }
            };
        }
    }
}
