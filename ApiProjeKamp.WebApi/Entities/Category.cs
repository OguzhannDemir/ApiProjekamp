using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ApiProjeKamp.WebApi.Entities
{
    public class Category
    {


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}
