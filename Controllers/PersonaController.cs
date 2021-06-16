using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiante.Context;
using ApiEstudiante.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiante.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext context;
        public PersonaController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            //Error handling Try-catch
            try
            {
                return Ok(context.persona.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //api/v1/persona/12563
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(persona => persona.id == id);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Persona persona)
        {
            try
            {
                context.persona.Add(persona);
                context.SaveChanges();
                return CreatedAtRoute("GetById", new { persona.id }, persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Persona persona)
        {
            try
            {
                if (persona.id == id) 
                {
                    context.Entry(persona).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetByIt", new { id = persona.id }, persona);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(p => p.id == id);
                if (persona != null)
                {
                    context.persona.Remove(persona);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}