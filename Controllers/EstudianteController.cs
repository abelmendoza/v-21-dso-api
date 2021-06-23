using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiante.Context;
using Microsoft.EntityFrameworkCore;
using ApiEstudiante.Models;


namespace ApiEstudiante.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudianteController(AppDbContext context) 
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.estudiante.Include(e => e.persona).Include(e => e.carrera).ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var estudiante = _context.estudiante.Include(e => e.persona).Include(e => e.carrera).FirstOrDefault(e => e.id == id);
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
       public ActionResult Post([FromBody] Estudiante estudiante)
        {
            try
            {
                _context.estudiante.Add(estudiante);
                _context.SaveChanges();
                return CreatedAtRoute("Get",new { estudiante.id },estudiante);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante.id == id)
                {
                    _context.Entry(estudiante).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Get", new { id = estudiante.id }, estudiante);
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
                var estudiante = _context.estudiante.FirstOrDefault(e => e.id == id);
                if (estudiante != null)
                {
                    _context.estudiante.Remove(estudiante);
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

