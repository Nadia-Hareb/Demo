using CRUD.API.Dev.RessourceData;
using CRUD.API.Dev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CRUD.API.Dev.Controllers
{
    
    [ApiController]
    public class RessourceController : ControllerBase
    {
        private readonly IRessourceData _ressource;
        public RessourceController(IRessourceData ressource)
        {
            _ressource = ressource;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetRessources()
        {
           
            return Ok(_ressource.GetRessources());
        }

        //[HttpGet]
        //[Route("api/[controller]/{id}")]
        //public IActionResult GetRessource(Guid id)
        //{
        //    var ressource = _ressource.GetRessource(id);
        //    if (ressource != null)
        //    {
        //        return Ok(ressource);
        //    }
        //    return NotFound($"Employe with Id {id} was not found");
               
        //}

        [HttpGet]
        [Route("api/[controller]/{number}")]
        public IActionResult GetRessource(string number)
        {
            var ressource = _ressource.GetRessource(number);
            if (ressource != null&&ressource.Count>0)
            {
                return Ok(ressource);
            }
            else
            return NotFound($"Ressource with Id {number} was not found");

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRessource(Ressource ressource)
        {
            var doc = _ressource.AddRessource(ressource);
            if (ressource != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + ressource.Id, ressource);                    
                 
            }
            return NotFound("Employe  was not found");

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteRessource(Guid id)
        {
            var ressource = _ressource.GetRessource(id);
            if (ressource!= null)
            {
                _ressource.DeleteRessource(ressource);
                return Ok();
                    
            }
            return NotFound($"Ressource{id} was not found");
        }



        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditRessource(Guid id, Ressource ressource)
        {
            var existantressource = _ressource.GetRessource(id);
            if (existantressource != null)
            {
                ressource.Id = existantressource.Id;
                _ressource.EditRessource(ressource);
                return Ok(ressource);
               
            }
            return NotFound($"Document {id} was not found");
        }
    }
}
