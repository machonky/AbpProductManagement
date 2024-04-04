using Xunit;
using ProductManagement.Products;

namespace ProductManagement.EntityFrameworkCore.Applications;

[Collection(ProductManagementTestConsts.CollectionDefinitionName)]
public class EfCoreProductAppService_Tests : ProductAppService_Tests<ProductManagementEntityFrameworkCoreTestModule>
{

}