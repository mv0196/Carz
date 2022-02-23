namespace Carz.Common.Configuration
{
    public class SqlServerConfiguration
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get { return $"Server={this.HostName};Database={this.DatabaseName};User Id={this.Username};Password={this.Password};"; } }
    }
}
