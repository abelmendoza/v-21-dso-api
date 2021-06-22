using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiante.Context;
using Microsoft.EntityFrameworkCore;

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
    }
}

