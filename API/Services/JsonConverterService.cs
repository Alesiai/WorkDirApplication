using System.Text;
using API.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class JsonConverterService : IJsonConverterService
    {
        public void GetStringFromJson(string folder, IFormFile file)
        {
            var res = new StringBuilder();

            using (var reader = new StreamReader(file.OpenReadStream())){
                while (reader.Peek() >= 0)
                    res.AppendLine(reader.ReadLine());
            }

            var structure = JsonConvert.DeserializeObject<JObject>(res.ToString());
            
            CreateDirectoriesFromJson(folder, structure);
        }

        private void CreateDirectoriesFromJson(string folder, JToken children)
        {
            var dirictories = children.Children().Select(_ => folder).ToList();

            int i = 0;
            foreach(var child in children.Children())
            {
                
                if(child is JProperty property){
                    folder = dirictories[i] + property.Name + "/";
                    System.IO.Directory.CreateDirectory(folder);
                }

               CreateDirectoriesFromJson(folder, child);
               i++;
            }
        }
    }
}