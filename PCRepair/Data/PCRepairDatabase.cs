using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using PCRepair.Models;

namespace PCRepair.Data
{
    public class PCRepairDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PCRepairDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MyRequest>().Wait();
        }

        public Task<List<MyRequest>> GetMyRequestsAsync()
        {
            //возвращает все заявки
            return database.Table<MyRequest>().ToListAsync();
        }

        public Task<MyRequest> GetMyRequestAsync(int id)
        {
            //возвращает одну заявки
            return database.Table<MyRequest>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveMyRequestAsync(MyRequest task)
        {
            if (task.ID != 0)
            {
                // Обновляет существующую заявку
                return database.UpdateAsync(task);
            }
            else
            {
                // Сохраняет новую заявку
                return database.InsertAsync(task);
            }
        }

        public Task<int> DeleteMyRequestAsync(MyRequest task)
        {
            // Delete a note.
            return database.DeleteAsync(task);
        }
    }
}