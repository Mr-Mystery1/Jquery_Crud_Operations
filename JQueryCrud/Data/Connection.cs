namespace JQueryCrud.Data
{
    public class Connection
    {
        private static string dbcs = "Server=RISHABH\\SQLEXPRESS;Database=CrudJQuery;Trusted_Connection=True";
        public static string cs { get => dbcs; }
    }
}
