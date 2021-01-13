using CRUDNetCore.Data;
using CRUDNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDNetCore.Controllers
{
    public class LibrosController : Controller
    {
        //este metodo es el que me permite accerder a la base de datos

        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)//como parametro ApplicationDb
        {
            //cogemos la variabel context y  la igualamos a lo que vamos a recibir en el contexto

            _context = context;

        }

        //http Get index
        public IActionResult Index()
        {
            //creamos una lista del modelo libro - llamada listalibro = 

            IEnumerable<Libro> listalibros = _context.Libro;

            return View(listalibros);
        }

        //http get Create
        public IActionResult Create()
        {
            

            return View();
        }


        //http POST Create
        [HttpPost]
        [ValidateAntiForgeryToken] //proteccion para formularios y no se puedan hacer peticiones facilmente con un bots enviar registros masivos
        public IActionResult Create(Libro libro) //recibe como parametro el Modelo libro instanciado en libro
        {
            //validar el modelo

            if(ModelState.IsValid) //va tener las condiciones de los campos y los campos si es requerido la cantidad de texto etc. si esto es valido entonces
            {
                //ingresamos con contex instanciamos context usamos bda ya aqui podemos acceder a libro llamamos al metodo add aqui mandamos libro 

                _context.Libro.Add(libro);
                _context.SaveChanges(); //aqui guardamos los cambios.

                TempData["mensaje"] = "El libro se ha creado satisfactoriamente.";

                return RedirectToAction("Index"); //cuando presione guardar retorne 

            }

            return View();
        }

        [HttpGet]

        //http get Edit para editar
        public IActionResult Edit(int? id) //recibe un entero
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //si lo de arriba se cumple es decir que el libro exista entonces obtenemos datos del libro

            var libro = _context.Libro.Find(id);

            if (libro == null) //si no se encuentra el libro por el id entonces retrone notfoung
            {
                return NotFound();
            }



            return View(libro); //si lo anterior se cumple retorna el parametro libro
        }

        //http post para edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro) 
        {
          

            if (ModelState.IsValid) 
            {
                

                _context.Libro.Update(libro);
                _context.SaveChanges(); 

                TempData["mensaje"] = "El libro se ha Modificado satisfactoriamente.";

                return RedirectToAction("Index"); 

            }

            return View();
        }

        //http get delete
                                
        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //si lo de arriba se cumple es decir que el libro exista entonces obtenemos datos del libro

            var libro = _context.Libro.Find(id); //obtenemos el libro

            if (libro == null) //si no se encuentra el libro por el id entonces retrone notfoung
            {
                return NotFound();
            }



            return View(libro); //si lo anterior se cumple retorna el parametro libro
        }


        //http post para Delete
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //obtener el libro por id

            var libro = _context.Libro.Find(id);
            if(libro == null) { return NotFound(); }
           

                _context.Libro.Remove(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha Eliminado satisfactoriamente.";

                return RedirectToAction("Index");

            

            
        }

    }
}
