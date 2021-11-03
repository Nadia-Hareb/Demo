using CRUD.API.Dev.Models;
using CRUD.API.Dev.RessourceContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Dev.RessourceData
{
    public class SqlRessourceData : IRessourceData
    {

        private readonly DBRessourceContext _context;
        public SqlRessourceData(DBRessourceContext context)
        {
            _context = context;
        }

        public Ressource AddRessource(Ressource ressource)
        {
            ressource.Id = Guid.NewGuid();
           _context.Ressources.Add(ressource);
           _context.SaveChanges();
            return ressource;

        }

        public void DeleteRessource(Ressource ressource)
        {
            _context.Ressources.Remove(ressource);
            _context.SaveChanges();
        }

        public Ressource EditRessource(Ressource ressource)
        {
            var existingRessource = _context.Ressources.Find(ressource.Id);
            if (existingRessource!=null)
            {
                existingRessource.Name = ressource.Name;
                existingRessource.DocPath = ressource.DocPath;
                existingRessource.EffectiveDate = ressource.EffectiveDate;
                existingRessource.Title = ressource.Title;
                existingRessource.Number = ressource.Number;
                existingRessource.Doctype = ressource.Doctype;
                _context.Ressources.Update(existingRessource);
                _context.SaveChanges();
            }
                           
           
            return ressource;
           
           
        }

        public Ressource GetRessource(Guid Id)
        {
            var employee= _context.Ressources.Find(Id);
            return employee;
           // return _context.Ressources.SingleOrDefault(item=>item.Id== Id);
        }

        public List<Ressource> GetRessource(string number)
        {
            return _context.Ressources.Where(item => item.Number == number).ToList();
        }

        public List<Ressource> GetRessources()
        {
           return  _context.Ressources.ToList();
        }
    }
}
