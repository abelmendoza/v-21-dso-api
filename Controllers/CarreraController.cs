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
    public class CarreraController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarreraController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.carrera.ToList());
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
                var carrera = _context.carrera.FirstOrDefault(carrera => carrera.id == id);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Carrera carrera)
        {
            try
            {
                _context.carrera.Add(carrera);
                _context.SaveChanges();
                return CreatedAtRoute("Get", new { carrera.id }, carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carrera carrera)
        {
            try
            {
                if (carrera.id == id)
                {
                    _context.Entry(carrera).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Get", new { id = carrera.id }, carrera);
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
                var carrera = _context.carrera.FirstOrDefault(c => c.id == id);
                if (carrera != null)
                {
                    _context.carrera.Remove(carrera);
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