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
        private readonly AppDbContext _context;
        public PersonaController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_context.persona.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var persona = _context.persona.FirstOrDefault(persona => persona.id == id);
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
                _context.persona.Add(persona);
                _context.SaveChanges();
                return CreatedAtRoute("GetById", new { persona.id }, persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Persona persona)
        {
            try
            {
                if (persona.id == id)
                {
                    _context.Entry(persona).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetById", new { id = persona.id }, persona);
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
                var persona = _context.persona.FirstOrDefault(p => p.id == id);
                if (persona != null)
                {
                    _context.persona.Remove(persona);
                    _context.SaveChanges();
                    return Ok(id);
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

    }
}