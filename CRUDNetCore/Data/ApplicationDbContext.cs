using CRUDNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDNetCore.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)

        {
                                
        }
        
        //aca vamos a instanciar el primer modelo

        public DbSet<Libro> Libro { get; set; }


    }
}
