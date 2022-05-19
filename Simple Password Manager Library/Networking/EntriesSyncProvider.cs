using Newtonsoft.Json;
using SimplePM.Library.Assets.Processing;
using SimplePM.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplePM.Library.Networking
{
    public static class EntriesSyncProvider
    {
        /// <summary>
        /// Performs three step client-server entries synchronization. 
        /// Step 1: Performs request to get all entries stored on server side id's and versions. 
        /// Step 2: Check data internal storage for changes and performs request to get full data for entries that should be added or updated
        /// Step 3: Performs request to post all entries changed on client side
        /// </summary>
        /// <param name="processor">EntriesProcessor instance</param>
        /// <param name="ownerID">User account identificator</param>
        /// <exception cref="ArgumentNullException">The ownerID parameter is null or whitespace
        /// -or- EntriesProcessor instance is not initialized</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        public static async Task SynchronizeAsync(this EntriesProcessor processor, string ownerID)
        {
            if (String.IsNullOrWhiteSpace(ownerID))
            {
                throw new ArgumentNullException(nameof(ownerID));
            }
            if (!ConnectivityManager.IsAnyNetworkAvailable())
            {
                throw new HttpRequestException("No suitable connections detected");
            }
            Dictionary<string, string> headers = new Dictionary<string, string> 
            {
                { "ownerID", ownerID }
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.Entries, "checklist", null, headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
            List<Entry> checklist = JsonConvert.DeserializeObject<List<Entry>>(response.ResponseMessage);
            Dictionary<string, EntrySyncOperation> updatelist = processor.CheckForUpdates(checklist);
            string[] idList = updatelist.Keys.ToArray();
            Dictionary<string, string[]> arrayHeaders = new Dictionary<string, string[]>
            {
                { "idList", idList }
            };
            response = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.Entries, "updatelist", null, headers, arrayHeaders);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
            List<Entry> updates = JsonConvert.DeserializeObject<List<Entry>>(response.ResponseMessage);
            processor.AddOrUpdateToStorage(updatelist, updates);
            response = await HttpProvider.CreateAndSend(HttpMethod.Post, ServiceType.Entries, null, processor.RetrieveSyncOperationsList().ToList(), headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }
    }
}
