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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TipoUsuarioController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.TipoUsuario.ToList());
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
                var tipoUsuario = _context.TipoUsuario.FirstOrDefault(tipoUsuario => tipoUsuario.id == id);
                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(tipoUsuario);
                _context.SaveChanges();
                return CreatedAtRoute("Get", new { tipoUsuario.id }, tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                if (tipoUsuario.id == id)
                {
                    _context.Entry(tipoUsuario).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Get", new { id = tipoUsuario.id }, tipoUsuario);
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
                var tipoUsuario = _context.TipoUsuario.FirstOrDefault(tipoUsuario => tipoUsuario.id == id);
                if (tipoUsuario != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuario);
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