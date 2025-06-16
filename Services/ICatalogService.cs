using eShop.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eShop.Services
{
    public interface ICatalogService
    {
       Task<Catalog> GetCatalogItems(int pageIndex, int itemsPages,
                                      int? brandId, int? typeId);
        Task<IEnumerable<SelectListItem>> GetBrands();

        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}
