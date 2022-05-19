using System;

namespace SimplePM.Library.Models
{
    [Serializable]
    public class Entry : IComparable<Entry>
    {
        public EntrySyncOperation SyncOperation { get; set; }
        public string ID { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int CompareTo(Entry other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}