namespace Carz.Common.Configuration
{
    public class MongoDbConfiguration
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string  Password { get; set; }
        public string ConnectionString { get { return $"mongodb://{this.Username}:{this.Password}@{this.HostName}:{this.Port}/admin"; } }

    }
}
