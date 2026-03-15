using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Project.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly string FilePath;

        protected RepositoryBase(string filePath)
        {
            FilePath = filePath;
            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            var directory = Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public virtual List<T> GetAll()
        {
            if (!File.Exists(FilePath))
                return new List<T>();

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public virtual void Add(T item)
        {
            var items = GetAll();
            items.Add(item);
            SaveAll(items);
        }

        protected virtual void SaveAll(List<T> items)
        {
            var json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
