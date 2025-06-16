using eShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShop.ViewModels
{
    public class CatalogIndex
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        public int? BrandFilterApplied { get; set; }

        public int? TypeFilterApplied { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

    }
}
