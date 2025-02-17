using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.Dto;

namespace WebApplication5.controller
{
    [Route("api/Beszallito")]
    [ApiController]
    public class BeszallitoController : ControllerBase 
    { 
        [HttpPost]
        public ActionResult<Beszallitok> Post(CreateBeszallitoDto createBeszallitoDto)  
        {
            using (var context = new RaktarContext())
            {
                var beszallito = new Beszallitok()  
                {
                    Id = createBeszallitoDto.Id,
                    Nev = createBeszallitoDto.Nev,
                };
                if (createBeszallitoDto.Id != null)
                {
                    context.Add(beszallito);
                    context.SaveChanges();
                    return Ok(beszallito);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Beszallitok> GetAll()
        {
            using (var context = new RaktarContext())
            {
                return Ok(context.Beszallitoks.ToList());  
            }
        }

        [HttpGet("GetById")]
        public ActionResult<Beszallitok> GetById(int id)
        {
            using (var context = new RaktarContext())
            {
                var beszallito = context.Beszallitoks.FirstOrDefault(x => x.Id == id); 
                if (beszallito != null)
                {
                    return Ok(beszallito);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Beszallitok> Put(int id, UpdateBeszallitoDto updateBeszallitoDto)
        {
            using (var context = new RaktarContext())
            {
                var existingBeszallito = context.Beszallitoks.FirstOrDefault(x => x.Id == id);             if (existingBeszallito != null)
                {
                    existingBeszallito.Nev = updateBeszallitoDto.Nev;
                    context.SaveChanges();
                    return Ok("Beszállító frissítve.");
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Beszallitok> Delete(int id)
        {
            using (var context = new RaktarContext())
            {
                var delBeszallito = context.Beszallitoks.FirstOrDefault(x => x.Id == id);

                if (delBeszallito != null)
                {
                    context.Remove(delBeszallito);
                    context.SaveChanges();
                    return Ok("Beszállító törölve.");
                }
                return NotFound();
            }
        }
    }
}
