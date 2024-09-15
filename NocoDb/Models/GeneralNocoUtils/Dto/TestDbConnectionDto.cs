using JetBrains.Annotations;

namespace NocoDb.Models.GeneralNocoUtils.Dto
{
    public class TestDbConnectionDto
    {
        public DbType Client { get; }
        public string Host { get; }
        public string Port { get; }
        public string User { get; }
        public string Password { get; }
        public string Database { get; }
        
        public TestDbConnectionDto(
            DbType client, 
            [NotNull]string host, 
            [NotNull]string port, 
            [NotNull]string user, 
            [NotNull]string password, 
            string database)
        {
            Client = client;
            Host = host;
            Port = port;
            User = user;
            Password = password;
            Database = database;
        }
    }
}