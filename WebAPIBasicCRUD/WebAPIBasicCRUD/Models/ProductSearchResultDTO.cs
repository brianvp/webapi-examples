using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIBasicCRUD.Models
{
    public class ProductSearchResultDTO
    {
 
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string PartNumberName { get; set; }
        public string InventoryPartNumber { get; set; }
        public decimal? ListPrice { get; set; }
        public string CategoryName { get; set; }


    }
}
