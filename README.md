# Perticari Product Manager 🏗️

Este es un sistema interno que estoy desarrollando para la gestión de productos de una distribuidora de hierro y acero (**Perticari**). 

El objetivo es facilitar la búsqueda de productos que tienen muchas variantes (medidas, materiales, tipos) mediante una interfaz dinámica que se va armando sola a medida que elegís categorías.

## 🛠️ Cómo funciona por dentro
En lugar de hardcodear mil botones, armé un sistema de **Nodos recursivos**:
- Cada nivel de búsqueda es un "Nodo" que sabe qué opciones tiene y cuál es el siguiente paso.
- La UI genera paneles (`FlowLayoutPanel`) automáticamente.
- Si cambiás una opción de arriba, el sistema limpia los paneles de abajo usando `Tags` para mantener el orden.
- El filtrado final usa **LINQ** sobre un `Dictionary` de atributos, lo que me permite agregar productos muy distintos (como un clavo o una chapa) sin romper el buscador.

## 📸 Screenshots (UX/UI Design)

### Idea primitiva de la UX/UI
![Main Interface](screenshots/ux.ui_old.jfif)

### UX/UI mejorada (diseño final)
![Data Grid](screenshots/ux.ui_new.png)
*Vista de productos filtrados con el rebranding aplicado.*

### Árbol de productos (Primitivo)
![Data Grid](screenshots/mapa_old.png)
*Mapa parcial de como funciona la ramificacion de cada producto.*

### Árbol de productos (Actual)
![Data Grid](screenshots/mapa_new.png)
*Mapa mejorado y más visual.*

## 📌 Pendientes / Roadmap
- [ ] Mover las clases `Producto` y `Nodo` a archivos separados (Refactor OOP).
- [ ] Implementar la carga de datos desde un JSON externo.
- [ ] Pulir el auto-scroll suave cuando aparece un bloque nuevo.

---
**Proyecto desarrollado por Joaquín Altamirano**
