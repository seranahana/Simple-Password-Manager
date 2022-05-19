using System;
using System.Collections.Generic;
using System.IO;
using SimplePM.Library.Serialization;
using SimplePM.Library.Models;

namespace SimplePM.Library.Assets.DataAccess
{
    internal class SyncOperationsDataAccess
    {
        private const string fileName = "spm100-so.bin";
        private static Dictionary<string, char> syncOperationsCache;

        public SyncOperationsDataAccess()
        {
            try
            {
                syncOperationsCache = JsonSerializer.ReadFromJsonFile<Dictionary<string, char>>(fileName);
            }
            catch (FileNotFoundException)
            {
                syncOperationsCache = new Dictionary<string, char>();
            }
        }

        public void Create(string id, EntrySyncOperation syncOperation)
        {
            switch (syncOperation)
            {
                case EntrySyncOperation.Create:
                    syncOperationsCache.Add(id, '+');
                    break;
                case EntrySyncOperation.Update:
                    syncOperationsCache.Add(id, '#');
                    break;
                case EntrySyncOperation.Delete:
                    syncOperationsCache.Add(id, '-');
                    break;
            }
        }

        public IEnumerable<Entry> RetrieveAll()
        {
            IEnumerable<Entry> result = new List<Entry>();
            foreach (var syncOperation in syncOperationsCache)
            {
                Entry entry = new Entry();
                entry.ID = syncOperation.Key;
                switch (syncOperation.Value)
                {
                    case '+':
                        entry.SyncOperation = EntrySyncOperation.Create;
                        break;
                    case '#':
                        entry.SyncOperation = EntrySyncOperation.Update;
                        break;
                    case '-':
                        entry.SyncOperation = EntrySyncOperation.Delete;
                        break;
                }
            }
            return result;
        }

        public bool Delete(string id)
        {
            return syncOperationsCache.Remove(id);
        }

        public void ClearCache()
        {
            syncOperationsCache.Clear();
        }

        public void Save()
        {
            JsonSerializer.WriteToJsonFile(fileName, syncOperationsCache);
        }
    }
}
