namespace CommonWpf.Configuration
{
    public sealed class ConnectionOption
    {
        public const string Position = nameof(Position);

        public string Sqlite { get; set; }

        public string Mysql { get; set; }
    }
}
