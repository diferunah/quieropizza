using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public List<Producto>  ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _contexto.Productos.Include("Categoria").ToList(); //incluye en producto las cateogorias
                
            return ListadeProductos;
        }

        public List<Producto> ObtenerProductosActivos()
        {
            ListadeProductos = _contexto.Productos.Include("Categoria").Where(r => r.Activo == true).OrderBy(r => r.Descripcion).ToList();

            return ListadeProductos;
        }

        public void GuardarProducto(Producto producto) //recibe y guarda el producto
        {
            if (producto.Id ==0)
            {
                _contexto.Productos.Add(producto); //guarda el producto que recibe de la vista
            }
            else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id); //busca en bd el producto existente

                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.Precio = producto.Precio;
                productoExistente.UrlImagen = producto.UrlImagen; //actualiza la informacion cuando editamos
            }
            
            _contexto.SaveChanges(); //guarda los cambios realizados
        }

        public Producto ObtenerProducto(int id)
        {
            var producto = _contexto.Productos.Find(id); //busca en bd el id
            return producto;
        }

        public void EliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);
            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }
    }
}
