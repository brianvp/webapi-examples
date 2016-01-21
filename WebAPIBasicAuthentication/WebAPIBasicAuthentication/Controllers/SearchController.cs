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
using WebApiBasicAuthentication.Models;
using WebAPIBasicAuthentication.Results;
using WebAPIBasicAuthentication.Filters;

namespace WebApiBasicAuthentication.Controllers
{
    [IdentityBasicAuthentication] // Enable Basic authentication for this controller.
    [RequireHttps]
    [Authorize] // Require authenticated requests.
    public class SearchController : ApiController
    {
        private BikeStoreContext db = new BikeStoreContext();

        //path with custom route
        // /api/search/PartNumbers?modelName=tape
        // /api/search/PartNumbers?partNumberName=Red
        // /api/search/PartNumbers?modelName=tape&partNumberName=Red
        [Route("api/Search/PartNumbers/")]
        [HttpGet]
        [ResponseType(typeof(ProductSearchResultDTO))]
        public IHttpActionResult PartNumberSearch(string modelName = null, string partNumberName = null) 
        {
            var query = from md in db.Models
                        join pn in db.PartNumbers
                        on md.ModelId equals pn.ModelId
                        join ct in db.Categories
                            on md.CategoryId equals ct.CategoryId
                        where (md.Name.Contains(modelName) || modelName == null) &&
                              (pn.Name.Contains(partNumberName) || partNumberName == null)
                        select new ProductSearchResultDTO { ModelId = md.ModelId, ModelName = md.Name, PartNumberName = pn.Name, InventoryPartNumber = pn.InventoryPartNumber, ListPrice = pn.ListPrice, CategoryName = ct.Name };

            return Ok(query);
        }

        //api/Search/models?modelName=tape
        [Route("api/search/models/")]
        [HttpGet]
        public IHttpActionResult ModelSearch(string modelName)
        {

            var query = from md in db.Models
                        join ct in db.Categories
                            on md.CategoryId equals ct.CategoryId
                        where (md.Name.Contains(modelName) || modelName == null) 
                        select new  { ModelId = md.ModelId, ModelName = md.Name, CategoryName = ct.Name };

            return Ok(query);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
