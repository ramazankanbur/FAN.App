using StackExchange.Redis;

namespace FAN.App.Redis
{
    public static class RedisConnection
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisConnection()
        {
            LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost:6379"); 
            });
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;
    }
}
