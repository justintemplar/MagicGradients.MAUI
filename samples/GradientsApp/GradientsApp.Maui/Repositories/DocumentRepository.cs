using LiteDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GradientsApp.Maui.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public void SetupMapper()
        {
            BsonMapper.Global.ResolveMember = (type, memberInfo, member) =>
            {
                if (member.DataType == typeof(DateTime))
                {
                    member.Deserialize = (v, m) => DateTime.ParseExact(v.AsString, DateTimeFormat, CultureInfo.InvariantCulture);
                    member.Serialize = (o, m) => ((DateTime)o).ToString(DateTimeFormat);
                }
            };
        }

        public async Task<T> GetDocument<T>(string fullPath)
        {
            var mapper = BsonMapper.Global;

            using var stream = await FileSystem.OpenAppPackageFileAsync(fullPath);


            using (var reader = new StreamReader(stream))
            {
                var value = JsonSerializer.Deserialize(reader);
                return mapper.ToObject<T>(value.AsDocument);
            }
        }

        public async Task<IEnumerable<T>> GetDocumentCollection<T>(string nameSpace, params string[] files)
        {
            var documents = new List<T>();
            var assembly = typeof(DocumentRepository).GetTypeInfo().Assembly;
            var mapper = BsonMapper.Global;

            foreach (var file in files)
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"{nameSpace}.{file}");
                //using (var stream = assembly.GetManifestResourceStream($"{nameSpace}.{file}"))
                using (var reader = new StreamReader(stream))
                {
                    var array = JsonSerializer.DeserializeArray(reader).Select(x => mapper.ToObject<T>(x.AsDocument));
                    documents.AddRange(array);
                }
            }

            return documents;
        }
    }
}
