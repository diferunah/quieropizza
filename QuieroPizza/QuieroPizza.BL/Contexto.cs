﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class Contexto: DbContext //heredamos funciones del entityframework
    {
        public Contexto() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\QuieroPizzaDB.mdf")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //evita la plurilizacion de las tablas
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

        public DbSet<Producto> Productos { get; set; } //crea una tabla en base producto
    }
}
