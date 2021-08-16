namespace Randerson.Infrastructure.MongoDb
{
    public class MongoConfig
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public MongoConfig()
        {
        }

        public MongoConfig(string database, string collection, string connectionString)
        {
            DatabaseName = database;
            CollectionName = collection;
            ConnectionString = connectionString;
        }

    }
}
