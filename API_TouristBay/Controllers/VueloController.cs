using API_TouristBay.Data;
using API_TouristBay.Models;
using API_TouristBay.Models.Pasajeros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_TouristBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {

        private readonly ApplicationDBContext _db;

        public VueloController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<VueloController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Vuelo> vuelos = await _db.Vuelo.ToListAsync();
            return Ok(vuelos);
        }

        // GET api/<VueloController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            Vuelo vuelo = await _db.Vuelo.FirstOrDefaultAsync(x => x.Id == Id);
            if (vuelo == null)
            {
                return BadRequest();
            }

            return Ok(vuelo);
        }

        // POST api/<VueloController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vuelo vuelo)
        {
            Vuelo vuelo2 = await _db.Vuelo.FirstOrDefaultAsync(x => x.Id == vuelo.Id);

            if (vuelo2 == null && vuelo != null)
            {
                await _db.Vuelo.AddAsync(vuelo);
                await _db.SaveChangesAsync();
                return Ok(vuelo);
            }

            return BadRequest("El vuelo ya existe");
        }

        // PUT api/<VueloController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Vuelo vuelo)
        {
            Vuelo vuelo2 = await _db.Vuelo.FirstOrDefaultAsync(x => x.Id == Id);
            if (vuelo2 != null)
            {

                vuelo2.Aerolinea = vuelo.Aerolinea != null ? vuelo.Aerolinea : vuelo2.Aerolinea;
                vuelo2.Clase = vuelo.Clase != null ? vuelo.Clase : vuelo2.Clase;
                vuelo2.Destino = vuelo.Destino != null ? vuelo.Destino : vuelo2.Destino;
                vuelo2.FSalida = vuelo.FSalida != null ? vuelo.FSalida : vuelo2.FSalida;
                vuelo2.HAbordaje = vuelo.HAbordaje != null ? vuelo.HAbordaje : vuelo2.HAbordaje;
                vuelo2.HSalida = vuelo.HSalida != null ? vuelo2.HSalida : vuelo2.HSalida;
                vuelo2.HLlegada = vuelo.HLlegada != null ? vuelo.HLlegada : vuelo2.HLlegada;
                vuelo2.Origen = vuelo.Origen != null ? vuelo.Origen : vuelo2.Origen;
                vuelo2.Precio = vuelo.Precio != null ? vuelo.Precio : vuelo2.Precio;
                vuelo2.PlzEconomicas = vuelo.PlzEconomicas != null ? vuelo.PlzEconomicas : vuelo2.PlzEconomicas;
                vuelo2.PlzPreferenciales = vuelo.PlzPreferenciales != null ? vuelo.PlzPreferenciales : vuelo2.PlzPreferenciales;
                _db.Vuelo.Update(vuelo2);
                await _db.SaveChangesAsync();
                return Ok(vuelo2);
            }
            return BadRequest("El vuelo no existe");
        }

        // DELETE api/<VueloController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Vuelo vuelo = await _db.Vuelo.FirstOrDefaultAsync(x => x.Id == Id);
            if (vuelo != null)
            {
                _db.Vuelo.Remove(vuelo);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();

        }
    }
}
