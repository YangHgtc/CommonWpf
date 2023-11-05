namespace CommonWpf.Configuration
{
    public sealed class ConnectionOption
    {
        public const string ConnectionString = nameof(ConnectionString);

        public string Sqlite { get; set; }

        public string Mysql { get; set; }
    }
}
