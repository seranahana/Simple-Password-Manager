using SimplePM.Library.Assets.DataAccess;
using SimplePM.Library.Cryptography;
using SimplePM.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePM.Library.Assets.Processing
{
    public class EntriesProcessor
    {
        private EntriesDataAccess entriesRepository;
        private SyncOperationsDataAccess syncOperationsRepository;

        public EntriesProcessor()
        {
            entriesRepository = new EntriesDataAccess();
            syncOperationsRepository = new SyncOperationsDataAccess();
        }
        /// <summary>
        /// Decrypts all entries in storage with current master password and encrypts with new one
        /// </summary>
        /// <param name="newMasterPassword">New master password</param>
        /// <param name="currentMasterPassword">Current master password</param>
        public void UpdateEntriesEncryption(string newMasterPassword, string currentMasterPassword)
        {
            List<Entry> entries = entriesRepository.RetrieveAll().ToList();
            foreach (var entry in entries)
            {
                string clearLogin = CryptographyProvider.AES.Decrypt(entry.Login, currentMasterPassword);
                string clearPassword = CryptographyProvider.AES.Decrypt(entry.Password, currentMasterPassword);
                entry.Login = CryptographyProvider.AES.Encrypt(clearLogin, newMasterPassword);
                entry.Password = CryptographyProvider.AES.Encrypt(clearPassword, newMasterPassword);
                entriesRepository.Update(entry.ID, entry);
            }
        }

        /// <summary>
        /// Encrypts login and password with AES alogirthm and adds entry to storage
        /// </summary>
        /// <param name="name">Entry name</param>
        /// <param name="url">Entry URL</param>
        /// <param name="login">Entry login</param>
        /// <param name="password">Entry password</param>
        /// <param name="masterpassword">Master password as a part of AES key</param>
        public void Create(string name, string url, string login, string password, string masterpassword)
        {
            string encryptedLogin = CryptographyProvider.AES.Encrypt(login, masterpassword);
            string encryptedPassword = CryptographyProvider.AES.Encrypt(password, masterpassword);
            string id = Guid.NewGuid().ToString("N");
            var entry = new Entry
            {
                ID = id,
                Name = name,
                URL = url,
                Login = encryptedLogin,
                Password = encryptedPassword
            };
            entriesRepository.Create(entry);
            syncOperationsRepository.Create(id, EntrySyncOperation.Create);
        }

        /// <summary>
        /// Removes single entry from storage by it's ID
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <exception cref="ArgumentException"></exception>
        public void Delete(string id)
        {
            if (!entriesRepository.Delete(id))
            {
                throw new ArgumentException($"Entry with id {id} not found");
            }
            syncOperationsRepository.Create(id, EntrySyncOperation.Delete);
        }

        /// <summary>
        /// Updates all entry values in storage
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <param name="name">Entry name</param>
        /// <param name="url">Entry URL</param>
        /// <param name="login">Entry login</param>
        /// <param name="password">Entry password</param>
        /// <param name="masterpassword">Master password as a part of AES key</param>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if entry not found, internal storage is corrupted or missing</exception>
        public void Update(string id, string name, string url, string login, string password, string masterpassword)
        {
            string encryptedLogin = CryptographyProvider.AES.Encrypt(login, masterpassword);
            string encryptedPassword = CryptographyProvider.AES.Encrypt(password, masterpassword);
            var updatedEntry = new Entry
            {
                ID = id,
                Name = name,
                URL = url,
                Login = encryptedLogin,
                Password = encryptedPassword
            };
            if (!entriesRepository.Update(id, updatedEntry))
            {
                throw new ArgumentException($"Entry with id {id} not found");
            }
            syncOperationsRepository.Create(id, EntrySyncOperation.Update);
        }

        /// <summary>
        /// Retrieves single entry from storage and decrypts it's user information
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <param name="masterpassword">Master password as a part of AES key</param>
        /// <returns>Returns SimplePM.Library.Models.Entry object</returns>
        public Entry Retrieve(string id, string masterpassword)
        {
            Entry entry = entriesRepository.Retrieve(id);
            entry.Login = CryptographyProvider.AES.Decrypt(entry.Login, masterpassword);
            entry.Password = CryptographyProvider.AES.Decrypt(entry.Password, masterpassword);
            return entry;
        }

        public IEnumerable<Entry> RetrieveSyncOperationsList()
        {
            IEnumerable<Entry> syncOperationsList = syncOperationsRepository.RetrieveAll();
            return syncOperationsList;
        }

        /// <summary>
        /// Retrieves all entries from storage and sorts it by name
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws this type of exception if sorting fails</exception>
        /// <returns>Entries as sorted List<SimplePM.Library.Models> (logins and passwords are encrypted) or null if repository is empty</returns>
        public IEnumerable<Entry> RetrieveAll()
        {
            IEnumerable<Entry> entries = entriesRepository.RetrieveAll();
            return entries;
        }

        public void SaveChanges()
        {
            entriesRepository.Save();
            syncOperationsRepository.Save();
        }

        /// <summary>
        /// For client-server synchronization purposes
        /// Updates existing entries in storage if they were modified earlier, or adds new one if entry does not exist at client side
        /// </summary>
        /// <param name="serverBase">Entries exising at client side</param>
        public Dictionary<string, EntrySyncOperation> CheckForUpdates(List<Entry> serverBase)
        {
            Dictionary<string, EntrySyncOperation> updatelist = new Dictionary<string, EntrySyncOperation>();
            foreach (var entry in serverBase)
            {
                Entry searchResult = entriesRepository.Retrieve(entry.ID);
                if (searchResult != null)
                {
                    if (entry.Version > searchResult.Version)
                    {
                        updatelist.Add(entry.ID, EntrySyncOperation.Update);
                    }
                }
                else
                {
                    updatelist.Add(entry.ID, EntrySyncOperation.Create);
                }
            }
            List<Entry> localBase = entriesRepository.RetrieveAll().ToList();
            foreach (var entry in localBase)
            {
                if (!serverBase.Exists(e => e.ID == entry.ID))
                {
                    entriesRepository.Delete(entry.ID);
                }
            }
            return updatelist;
        }

        public void AddOrUpdateToStorage(Dictionary<string, EntrySyncOperation> updatelist, List<Entry> updateValues)
        {
            foreach (var entry in updatelist)
            {
                Entry entryToModify = updateValues.FirstOrDefault(e => e.ID == entry.Key);
                if (entryToModify != null) 
                {
                    switch (entry.Value)
                    {
                        case EntrySyncOperation.Create:
                            entriesRepository.Create(entryToModify);
                            break;
                        case EntrySyncOperation.Update:
                            entriesRepository.Update(entry.Key, entryToModify);
                            break;
                    }
                }
            }
        }
    }
}