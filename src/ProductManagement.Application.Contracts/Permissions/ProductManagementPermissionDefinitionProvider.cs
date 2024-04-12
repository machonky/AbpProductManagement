using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManagement.Permissions;

public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var groupPermission = context.AddGroup(ProductManagementPermissions.GroupName, L(ProductManagementPermissions.PermissionPrefix + ProductManagementPermissions.GroupName))
        .AddPermission(ProductManagementPermissions.Products.GroupPrefix, L(ProductManagementPermissions.Products.Display.Default));

        groupPermission.AddChild(ProductManagementPermissions.Products.Create, L(ProductManagementPermissions.Products.Display.Create));
        groupPermission.AddChild(ProductManagementPermissions.Products.Edit, L(ProductManagementPermissions.Products.Display.Edit));
        groupPermission.AddChild(ProductManagementPermissions.Products.Delete, L(ProductManagementPermissions.Products.Display.Delete));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagementResource>(name);
    }
}
