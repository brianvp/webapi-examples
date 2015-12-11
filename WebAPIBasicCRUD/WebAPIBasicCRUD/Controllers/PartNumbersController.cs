using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIBasicCRUD.Models;

namespace WebAPIBasicCRUD.Controllers
{
    public class PartNumbersController : ApiController
    {
        private BikeStoreContext db = new BikeStoreContext();

        // GET: api/PartNumbers
        public IQueryable<PartNumber> GetPartNumbers()
        {
            return db.PartNumbers;
        }

        // GET: api/PartNumbers/5
        [ResponseType(typeof(PartNumber))]
        public IHttpActionResult GetPartNumber(int id)
        {
            PartNumber partNumber = db.PartNumbers.Find(id);
            if (partNumber == null)
            {
                return NotFound();
            }

            return Ok(partNumber);
        }

        // As opposed to using a dedicated search controller, we can perform a search here
        // using a sub resource is required, since with optional parameters the route:
        // api/PartNumbers
        // would me mappable to GetPartNumbers() and GetPartNumberSearch()
        // valid paths:
        // /api/PartNumbers/Search
        // /api/PartNumbers/Search?modelName=Tape
        // /api/PartNumbers/Search?partNumberName=Red
        // /api/PartNumbers/Search?modelName=Tape&partNumberName=Red
        [Route("api/PartNumbers/Search")]
        [ResponseType(typeof(ProductSearchResultDTO))]
        public IHttpActionResult GetPartNumberSearch(string modelName = null, string partNumberName = null)
        {

            var query = from md in db.Models
                        join pn in db.PartNumbers
                        on md.ModelId equals pn.ModelId
                        join ct in db.Categories
                            on md.CategoryId equals ct.CategoryId
                        where ( md.Name.Contains(modelName)|| modelName == null ) && 
                              (pn.Name.Contains(partNumberName) || partNumberName == null )
                        select new ProductSearchResultDTO { ModelId = md.ModelId, ModelName = md.Name, PartNumberName = pn.Name, InventoryPartNumber = pn.InventoryPartNumber, ListPrice = pn.ListPrice, CategoryName = ct.Name };

            return Ok(query);
        }

        // PUT: api/PartNumbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartNumber(int id, PartNumber partNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partNumber.PartNumberId)
            {
                return BadRequest();
            }

            db.Entry(partNumber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartNumberExists(id))
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

        // POST: api/PartNumbers
        [ResponseType(typeof(PartNumber))]
        public IHttpActionResult PostPartNumber(PartNumber partNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartNumbers.Add(partNumber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partNumber.PartNumberId }, partNumber);
        }

        // DELETE: api/PartNumbers/5
        [ResponseType(typeof(PartNumber))]
        public IHttpActionResult DeletePartNumber(int id)
        {
            PartNumber partNumber = db.PartNumbers.Find(id);
            if (partNumber == null)
            {
                return NotFound();
            }

            db.PartNumbers.Remove(partNumber);
            db.SaveChanges();

            return Ok(partNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartNumberExists(int id)
        {
            return db.PartNumbers.Count(e => e.PartNumberId == id) > 0;
        }
    }
}