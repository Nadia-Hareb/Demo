using CRUD.API.Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Dev.RessourceData
{
    public class MockRessourceData : IRessourceData
    {

        private List<Ressource> ressources = new List<Ressource>()

        {
            new Ressource(){Id= Guid.NewGuid(), Name= "Reglementation de quebec"},
            new Ressource(){Id= Guid.NewGuid(), Name= "Permis de Zonage"},
            new Ressource(){Id= Guid.NewGuid(), Name= "Municipalité de quebec"},
            new Ressource(){Id= Guid.NewGuid(), Name= "Zone a tariter"},
            new Ressource(){Id= Guid.NewGuid(), Name= "Zonage libre"},
            new Ressource(){Id= Guid.NewGuid(), Name= "Reglementation municipale"},
        };
        public List<Ressource> GetRessources()
        {
            return ressources;
        }

       public  Ressource AddRessource(Ressource ressource)
        {
            ressource.Id = Guid.NewGuid();
            ressources.Add(ressource);
            return ressource;
        }

        

       public  void DeleteRessource(Ressource ressource)
        {
            ressources.Remove(ressource);
        }

        

        public Ressource EditRessource(Ressource ressource)
        {
            var existantRessource = GetRessource(ressource.Id);
           
                existantRessource.Name = ressource.Name;

              
            return existantRessource;
        }

        

        public Ressource GetRessource(Guid Id)
        {
           return ressources.SingleOrDefault(item => item.Id == Id);
          
        }

        public List<Ressource> GetRessource(string number)
        {
            throw new NotImplementedException();
        }
    }
}
