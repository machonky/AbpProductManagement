using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Categories;
using ProductManagement.Products;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Web.Pages.Products;

public class CreateProductModalModel : ProductManagementPageModel
{
    [BindProperty]
    public CreateEditProductViewModel Product { get; set; }

    public SelectListItem[] Categories { get; set; }

    private readonly IProductAppService productAppService;

    public CreateProductModalModel(IProductAppService productAppService)
    {
        this.productAppService = productAppService;
    }

    public async Task OnGetAsync()
    {
        Product = new CreateEditProductViewModel 
        {
            ReleaseDate = Clock.Now,
            StockState = ProductStockState.PreOrder,
        };

        var categoryLookup =
            await productAppService.GetCategoriesAsync();

        Categories = categoryLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToArray();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await productAppService.CreateAsync(
            ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(Product));

        return NoContent();
    }
}
