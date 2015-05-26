using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;

namespace CEverett
{
    public static class FileHelper
    {
        private static string StorageConnectionString { get; set; }
        
        static FileHelper()
        {
            var account = CloudConfigurationManager.GetSetting("StorageAccountName");
            var key = CloudConfigurationManager.GetSetting("StorageAccountAccessKey");
            StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
        }
            
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
        
        public static async Task<string> ReadAllTextFromBlob(string containerName, string name)
        {
            var storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            var client = storageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            var blob = await container.GetBlobReferenceFromServerAsync(name);
            
            using(var ms = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(ms);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        
        public static async Task<T> ReadAllJsonFromBlob<T>(string containerName, string name)
        {
            return JsonConvert.DeserializeObject<T>(await ReadAllTextFromBlob(containerName, name));
        }
    }
}