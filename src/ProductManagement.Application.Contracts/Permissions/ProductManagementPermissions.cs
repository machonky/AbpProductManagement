namespace ProductManagement.Permissions;

public static class ProductManagementPermissions
{
    public const string GroupName = "ProductManagement";

    public static class Products
    {
        public const string Default = GroupName + nameof(Products);
        public const string Create = nameof(Default) + "." + nameof(Create);
        public const string Read = nameof(Default) + "." + nameof(Read);
        public const string Update = nameof(Default) + "." + nameof(Update);
        public const string Delete = nameof(Default) + "." + nameof(Delete);
    }
}
