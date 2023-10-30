using API_TouristBay.Data;
using API_TouristBay.Models.Pasajeros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_TouristBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroController : ControllerBase
    {

        private readonly ApplicationDBContext _db;

        public PasajeroController(ApplicationDBContext db)
        {
            _db = db;
        }


        // GET: api/<PasajeroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Pasajero> pasajeros = await _db.Pasajero.ToListAsync();
            return Ok(pasajeros);
        }

        // GET api/<PasajeroController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            Pasajero pasajero = await _db.Pasajero.FirstOrDefaultAsync(x => x.Id == Id);
            if (pasajero == null)
            {
                return BadRequest();
            }

            return Ok(pasajero);
        }

        // POST api/<PasajeroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pasajero pasajero)
        {
            Pasajero pasajero2 = await _db.Pasajero.FirstOrDefaultAsync(x => x.Id == pasajero.Id);

            if (pasajero2 == null && pasajero != null)
            {
                await _db.Pasajero.AddAsync(pasajero);
                await _db.SaveChangesAsync();
                return Ok(pasajero);
            }

            return BadRequest("El pasajero ya existe");
        }

        // PUT api/<PasajeroController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Pasajero pasajero)
        {
            Pasajero pasajero2 = await _db.Pasajero.FirstOrDefaultAsync(x => x.Id == Id);
            if (pasajero2 != null)
            {

                pasajero2.Nombre = pasajero.Nombre != null ? pasajero.Nombre : pasajero2.Nombre;
                pasajero2.Apellido = pasajero.Apellido != null ? pasajero.Apellido : pasajero2.Apellido;
                pasajero2.fNacimiento = pasajero.fNacimiento != null ? pasajero.fNacimiento : pasajero2.fNacimiento;
                pasajero2.Genero = pasajero.Genero != null ? pasajero.Genero : pasajero2.Genero;
                _db.Pasajero.Update(pasajero2);
                await _db.SaveChangesAsync();
                return Ok(pasajero2);
            }
            return BadRequest("El pasajero no existe");
        }

        // DELETE api/<PasajeroController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Pasajero pasajero = await _db.Pasajero.FirstOrDefaultAsync(x => x.Id == Id);
            if (pasajero != null)
            {
                _db.Pasajero.Remove(pasajero);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();

        }
    }
}
