namespace Api.Controllers
{
    using BD;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    [Authorize]
    [RoutePrefix("api/Specialities")]
    public class SpecialitiesController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        [Route("List")]
        public async Task<IHttpActionResult> GetSpecialities()
        {
            return Ok(await db.Specialities.ToListAsync());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> PostSpeciality(Speciality speciality)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            db.Specialities.Add(speciality);
            await db.SaveChangesAsync();

            return Ok(200);
        }

        [ResponseType(typeof(Speciality))]
        public async Task<IHttpActionResult> GetSpeciality(int id)
        {
            var speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            return Ok(speciality);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpeciality(int id, Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speciality.SpecialityId)
            {
                return BadRequest();
            }

            db.Entry(speciality).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Specialities/5
        [ResponseType(typeof(Speciality))]
        public async Task<IHttpActionResult> DeleteSpeciality(int id)
        {
            Speciality speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            db.Specialities.Remove(speciality);
            await db.SaveChangesAsync();

            return Ok(speciality);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialityExists(int id)
        {
            return db.Specialities.Count(e => e.SpecialityId == id) > 0;
        }
    }
}