using CRUD.API.Dev.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Dev.RessourceContext
{
    public class DBRessourceContext : DbContext
    {
        public DBRessourceContext([NotNullAttribute] DbContextOptions options) : base(options)
        { 
        }

        protected DBRessourceContext()
        {
        }
        public DbSet<Ressource> Ressources { get; set; }
    }
}
