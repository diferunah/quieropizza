using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");

            var nuevoUsuario1 = new Usuario();
            nuevoUsuario1.Nombre = "dixee";
            nuevoUsuario1.Contrasena = Encriptar.CodificarContrasena("dmolina");

            var nuevoUsuario2 = new Usuario();
            nuevoUsuario2.Nombre = "rosa";
            nuevoUsuario2.Contrasena = Encriptar.CodificarContrasena("rarita");

            var nuevoUsuario3 = new Usuario();
            nuevoUsuario3.Nombre = "nahyeli";
            nuevoUsuario3.Contrasena = Encriptar.CodificarContrasena("nahyeli123");

            var nuevoUsuario4 = new Usuario();
            nuevoUsuario4.Nombre = "limny";
            nuevoUsuario4.Contrasena = Encriptar.CodificarContrasena("ljared");

            contexto.Usuarios.Add(nuevoUsuario);
            contexto.Usuarios.Add(nuevoUsuario1);
            contexto.Usuarios.Add(nuevoUsuario2);
            contexto.Usuarios.Add(nuevoUsuario3);
            contexto.Usuarios.Add(nuevoUsuario4);
            
            base.Seed(contexto); //guarda una vez cada vez que corre la base de datos
        }
    }
}