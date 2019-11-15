using LocalEventReminder.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalEventReminder.Data
{
    public class LocalEventDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public LocalEventDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LocalEvent>().Wait();
        }

        public Task<List<LocalEvent>> GetEventsAsync()
        {
            return _database.Table<LocalEvent>().ToListAsync();
        }

        public Task<LocalEvent> GetEventAsync(int id)
        {
            return _database.Table<LocalEvent>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEventAsync(LocalEvent localEvent)
        {
            if (localEvent.ID != 0)
            {
                return _database.UpdateAsync(localEvent);
            }
            else
            {
                return _database.InsertAsync(localEvent);
            }
        }

        public Task<int> DeleteEventAsync(LocalEvent localEvent)
        {
            return _database.DeleteAsync(localEvent);
        }
    }
}
