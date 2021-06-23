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
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.usuario.Include(u => u.persona).Include(u => u.tipoUsuario).ToList());
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
                var usuario = _context.usuario.Include(u => u.persona).Include(u => u.tipoUsuario).FirstOrDefault(u => u.id == id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _context.usuario.Add(usuario);
                _context.SaveChanges();
                return CreatedAtRoute("Get", new { usuario.id }, usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.id == id)
                {
                    _context.Entry(usuario).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Get", new { id = usuario.id }, usuario);
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
                var usuario = _context.usuario.FirstOrDefault(u => u.id == id);
                if (usuario != null)
                {
                    _context.usuario.Remove(usuario);
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

