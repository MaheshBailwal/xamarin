using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App2.Services
{
    public interface IDataStore<T>
    {
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<bool> UpSertAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
