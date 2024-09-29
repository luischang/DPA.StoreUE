using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryDescriptionDTO
    {
        public string? Description { get; set; }
    }

    public class CategoryProductsDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ProductListDTO> Products { get; set; }

    }


}
