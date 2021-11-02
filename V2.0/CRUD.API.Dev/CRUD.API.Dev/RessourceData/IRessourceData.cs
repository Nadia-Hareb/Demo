using CRUD.API.Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Dev.RessourceData
{
    public interface IRessourceData
    {
        public List<Ressource> GetRessources();
        public Ressource GetRessource(Guid Id);
        public  Ressource AddRessource(Ressource ressource);
        public void DeleteRessource(Ressource ressource);
        public Ressource EditRessource(Ressource ressource);
    }
}
