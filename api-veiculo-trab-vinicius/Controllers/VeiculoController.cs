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
    [Route("v1/veiculos")]
    public class VeiculoController : ControllerBase
    {

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Veiculo>>> getAll([FromServices] DataContext context)
        {
            var veiculos = await context.Veiculos.Include(x => x.Modelo).ToListAsync();
            return veiculos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Veiculo>> getById([FromServices] DataContext context, int id)
        {
            var veiculo = await context.Veiculos.Include(x => x.Modelo)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return veiculo;
        }

        [HttpGet]
        [Route("modelo/{id:int}")]
        public async Task<ActionResult<List<Veiculo>>> getByIdModelo([FromServices] DataContext context, int id)
        {
            var veiculos = await context.Veiculos
                .Include(x => x.Modelo)
                .AsNoTracking()
                .Where(x => x.ModeloId == id)
                .ToListAsync();

            return veiculos;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Veiculo>> post([FromServices] DataContext context, 
            [FromBody]Veiculo model)
        {
            if (ModelState.IsValid)
            {
                context.Veiculos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Veiculo>> delete([FromServices]DataContext context, int id)
        {
            var x = await context.Veiculos.Include(x => x.Modelo)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            context.Veiculos.Remove(x);
            await context.SaveChangesAsync();
            return x;
        }

        
    }
}
