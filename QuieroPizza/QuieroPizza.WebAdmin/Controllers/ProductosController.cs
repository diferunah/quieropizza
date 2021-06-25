using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBL; //variable global 

        public ProductosController()
        {
            _productosBL = new ProductosBL();
        }
        // GET: Productos // envia pagina al cliente
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear() //GET para crear un producto
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);
        }

        [HttpPost] //atributo que envia de regreso
        public ActionResult Crear(Producto producto) //recibe un producto de regreso
        {
            _productosBL.GuardarProducto(producto); // Guarda el producto creado por el usuario

            return RedirectToAction("Index"); //Nos redireciona a l a vista index
        }

        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _productosBL.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        public ActionResult detalle(int id) //mantenimiento a detalle
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar (Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}