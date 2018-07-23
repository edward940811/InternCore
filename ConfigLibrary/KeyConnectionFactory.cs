using Microsoft.Extensions.Configuration;

namespace ConfigLibrary
{
    public static class KeyConnectionFactory
    {
        /// <summary>
        /// 取得appsettings key's value
        /// </summary>
        /// <param name="key">key name</param>
        /// <returns></returns>
        public static string Get(string key)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            return config[$"{key}"];
        }
    }
}