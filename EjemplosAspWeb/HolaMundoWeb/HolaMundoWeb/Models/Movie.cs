using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Agregar el nuget desde referencias/Agregar/administrarPaquetesNuget/Examinar/EntityFrameWork=Instalar
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

/*
 * Para agregar el entity manager, y con solo crear una clase poder hacer la base de datos y el contralador y las
 * vistas, se necesita, 
 * 1) instalar entity framewor como se dice arriba
 * 2) Crear la classe peliculas como este ejemplo y luego la clase que hereda de dbContext y crear el metodo DbSet<Movies>
 * 3) Agregar la cadena de coneccion en web.config.  ejemplo en el proyecto
 *  <connectionStrings>
    <add name="HolaMundoWeb" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=HolaMundoWeb;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Movies.mdf" providerName="System.Data.SqlClient" />
  </connectionStrings>
    4)llamar a la consola de administrador de paquetes y dar la orden update-database
    5)En migration ver que este en true AutomaticMigrationsEnabled = true;
    6)crear el controlador con vista usando entity frameword
    7)creara todo
 * */

namespace HolaMundoWeb.Models
{
    public class Movie
    {
        [Key]
        public int ÏD { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RelaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}