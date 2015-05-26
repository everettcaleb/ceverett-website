using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CEverett
{
    public static class FileHelper
    {       
        public static async Task<string> ReadAllText(string path)
        {
            using(var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using(var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        
        public static async Task<T> ReadAllJson<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(await ReadAllText(path));
        }
    }
}