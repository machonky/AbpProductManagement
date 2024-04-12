namespace ProductManagement.Permissions;

public class BasePermissions
{
    public const string PermissionPrefix = "Permission:";
}

public class ProductManagementPermissions : BasePermissions
{
    public const string GroupName = "ProductManagement";

    public class Products
    {
        public const string GroupPrefix = GroupName + "." + nameof(Products);
        public const string Default = GroupPrefix;
        public const string Create = GroupPrefix + "." + nameof(Create);
        public const string Edit = GroupPrefix + "." + nameof(Edit);
        public const string Delete = GroupPrefix + "." + nameof(Delete);

        public class Display
        {
            public const string Default = PermissionPrefix + GroupPrefix;
            public const string Create = PermissionPrefix + Products.Create;
            public const string Edit = PermissionPrefix + Products.Edit;
            public const string Delete = PermissionPrefix + Products.Delete;
        }
    }
}
