using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManagement.Permissions;

public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var g = context.AddGroup(ProductManagementPermissions.GroupName, L("ProductManagement"));
        g.AddPermission(ProductManagementPermissions.Products.Create, L("ProductCreation"));
        g.AddPermission(ProductManagementPermissions.Products.Read, L("ProductListing"));
        g.AddPermission(ProductManagementPermissions.Products.Update, L("ProductEditing"));
        g.AddPermission(ProductManagementPermissions.Products.Delete, L("ProductDeletion"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagementResource>(name);
    }
}
