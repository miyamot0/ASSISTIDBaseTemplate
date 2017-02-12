/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASSISTIDBaseTemplate.Storage
{
    public class ApplicationDatabase
    {
        /// <summary>
        /// Singleton
        /// </summary>
        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath"></param>
        public ApplicationDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DatabaseEntryModel>().Wait();
        }

        /// <summary>
        /// Get all items in db
        /// </summary>
        /// <returns></returns>
        public Task<List<DatabaseEntryModel>> GetItemsAsync()
        {
            return database.Table<DatabaseEntryModel>().ToListAsync();
        }

        /// <summary>
        /// Get the items that match the date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<DatabaseEntryModel> GetItemsMatchingDateString(string date)
        {
            var items = GetItemsAsync();

            return items.Result.FindAll(i => i.DateString.ToLower() == date.ToLower());
        }

        /// <summary>
        /// Get distinct values of columns
        /// </summary>
        /// <returns></returns>
        public List<string> GetDistinctSeriesByDate()
        {
            var items = GetItemsAsync();
            return items.Result.Select(i => i.DateString).Distinct().ToList();
        }

        /// <summary>
        /// Get item by row id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DatabaseEntryModel> GetItemAsync(int id)
        {
            return database.Table<DatabaseEntryModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Save item async
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> SaveItemAsync(DatabaseEntryModel item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        /// <summary>
        /// Delete item async
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> DeleteItemAsync(DatabaseEntryModel item)
        {
            return database.DeleteAsync(item);
        }
    }
}
