using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL; //variable global 

        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }
        // GET: Categorias // envia pagina al cliente
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        public ActionResult Crear() //GET para crear un producto
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost] //atributo que envia de regreso
        public ActionResult Crear(Categoria producto) //recibe un producto de regreso
        {
            _categoriasBL.GuardarCategoria(producto); // Guarda el producto creado por el usuario

            return RedirectToAction("Index"); //Nos redireciona a l a vista index
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Categoria producto)
        {
            _categoriasBL.GuardarCategoria(producto);
            return RedirectToAction("Index");
        }

        public ActionResult detalle(int id) //mantenimiento a detalle
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria producto)
        {
            _categoriasBL.EliminarCategoria(producto.Id);
            return RedirectToAction("Index");
        }
    }
}