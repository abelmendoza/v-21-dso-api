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
                return Ok(_context.estudiante.Include(e => e.persona).ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}