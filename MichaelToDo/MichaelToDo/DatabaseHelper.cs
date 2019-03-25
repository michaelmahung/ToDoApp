using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace MichaelToDo
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection database;

        //Constructor that will create a dbHelper with a device specific path
        public DatabaseHelper(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Task>().Wait();
        }

        //Returns a list of all available tasks asyncrononmously.
        public Task<List<Task>> GetItemsAsync()
        {
            return database.Table<Task>().ToListAsync();
        }

        //Makes a query to the database asking for all Tasks where Done is false/0;
        public Task<List<Task>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Task>("SELECT * FROM [Task] WHERE [Done] = 0");
        }

        //Returns a task by its ID - will return null if none is found.
        public Task<Task> GetItemAsync (int id)
        {
            return database.Table<Task>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        //Inserts or updates the table depending if the tasks ID already exists in the table.
        public Task<int> SaveItemAsync(Task task)
        {
            if (task.ID != 0)
            {
                return database.UpdateAsync(task);
            }else
            {
                return database.InsertAsync(task);
            }
        }

        //Deletes a task from the table basd on its ID.
        public Task<int> DeleteItemAsync(Task task)
        {
            return database.DeleteAsync(task);
        }
    }
}
