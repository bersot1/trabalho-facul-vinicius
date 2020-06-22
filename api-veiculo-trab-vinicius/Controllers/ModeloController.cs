using api_veiculo_trab_vinicius.data;
using api_veiculo_trab_vinicius.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_veiculo_trab_vinicius.Controllers
{
    [ApiController]
    [Route("v1/modelos")]
    public class ModeloController : ControllerBase
    {
       [HttpGet]
       [Route("getAll")]
        public async Task<ActionResult<List<Modelo>>> getAll([FromServices] DataContext context)
        {
            var modelo = await context.Modelos.ToListAsync();
            return modelo;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Modelo>> Post([FromServices] DataContext context,
            [FromBody]Modelo model)
        {
            if (ModelState.IsValid) 
            {
                context.Modelos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
