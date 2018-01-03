using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Registradora.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Display(Name = "Precio de venta")]
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
    }

    public class ProductoDBContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}