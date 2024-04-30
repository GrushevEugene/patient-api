using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using patient_api.Models;

namespace patient_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientDbContext _context;

        public PatientController(PatientDbContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        /// <param name="gtDate">Search type by greate than</param>
        /// <param name="ltDate">Search type by less than</param>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients(DateTime? gtDate, DateTime? ltDate)
        {
            var patients = _context.Patient.Include(p => p.Name).AsQueryable();
            if (ltDate.HasValue)
            {
                patients = patients.Where(p => p.Birthdate < ltDate);
            }
            if (gtDate.HasValue)
            {
                patients = patients.Where(p => p.Birthdate > gtDate);
            }
            return await patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            var patient = await _context.Patient.Include(p => p.Name).FirstOrDefaultAsync(mt => mt.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(Guid id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }
            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                _context.Name.Update(patient.Name);
                _context.Patient.Update(patient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Patients
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(Guid id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
