using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.Dto;

namespace WebApplication5.controller
{
    [Route("api/Termek")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Termekek> Post(CreateTermekDto createTermekDto)
        {
            using (var context = new RaktarContext())
            {
                var termek = new Termekek()
                {
                    Id = createTermekDto.Id,
                    Nev = createTermekDto.Nev,
                    Dbszam = createTermekDto.Dbszam,
                };
                if (createTermekDto.Id != null)
                {
                    context.Add(termek);
                    context.SaveChanges();
                    return Ok(termek);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Termekek> GetAll()
        {
            using (var context = new RaktarContext())
            {
                return Ok(context.Termekeks.ToList());
            }
        }

        [HttpGet("GetById")]
        public ActionResult<Termekek> GetById(int id)
        {
            using (var context = new RaktarContext())
            {
                var Termek = context.Termekeks.FirstOrDefault(x => x.Id == id);

                if (Termek != null)
                {
                    return Ok(Termek);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Termekek> Put(int id, UpdateTermekDto updateTermekDto)
        {
            using (var context = new RaktarContext())
            {
                var existingtermek = context.Termekeks.FirstOrDefault(x => x.Id == id);

                if (existingtermek != null)
                {
                    existingtermek.Dbszam = updateTermekDto.Dbszam;
                    context.SaveChanges();
                    return Ok("Termék frissítve.");
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Termekek> Delete(int id)
        {
            using (var context = new RaktarContext())
            {
                var deltermek = context.Termekeks.FirstOrDefault(x =>x.Id == id);

                if (deltermek != null)
                {
                    context.Remove(deltermek);
                    context.SaveChanges();
                    return Ok("Termék törölve.");
                }
                return NotFound();
            }
        }
    }
}
