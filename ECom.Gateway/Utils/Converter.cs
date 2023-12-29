using System.Text.Json;

namespace ECom.Gateway.Utils
{
    public static class Converter
    {
        public static string ConvertToJson<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
