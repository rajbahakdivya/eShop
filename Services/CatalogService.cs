using eShop.Infrastructure;
using eShop.Models;
using eShop.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eShop.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly CatalogContext _context;

        public CatalogService(CatalogContext context) { 
            _context = context;
        }
        public Task<IEnumerable<SelectListItem>> GetBrands()
        {
            throw new NotImplementedException();
        }

        public async Task<Catalog> GetCatalogItems(int pageIndex, int itemsPages, int? brandId, int? typeId)
        {
            var root = (IQueryable<CatalogItem>)_context.CatalogItems;

            if (typeId.HasValue)
            {
                root = root.Where(ci => ci.CatalogTypeId == typeId.Value);
            }

            if (brandId.HasValue)
            {
                root = root.Where(ci => ci.CatalogTypeId == brandId.Value);
            }

            var totalItems = await root.LongCountAsync();

            var itemOnPage = await root
                .Skip(itemsPages * pageIndex)
                .Take(itemsPages)
                .ToListAsync();

            itemOnPage = ComposePictureUrl(itemOnPage);

            return new Catalog
            {
                Data = itemOnPage,
                PageIndex = pageIndex,
                Count = (int)totalItems
            };
        }

        private List<CatalogItem> ComposePictureUrl(List<CatalogItem> items)
        {
            var baseUrl = "";
            items.ForEach(x =>
                            x.PictureUrl = x.PictureUrl.Replace("http://catalogbaseurltobereplaced", baseUrl)
                             );

            return items;
        }

        public Task<IEnumerable<SelectListItem>> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}
