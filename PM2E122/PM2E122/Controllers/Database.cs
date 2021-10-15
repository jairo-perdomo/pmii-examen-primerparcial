using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2E122.Models;
using SQLite;

namespace PM2E122.Controllers
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(String databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);

            database.CreateTableAsync<Localizacion>().Wait();
        }

        // CRUD Operations with SQLite

        // Get Location List
        public Task<List<Localizacion>> getListLocations()
        {
            return database.Table<Localizacion>().ToListAsync();
        }


        // Get Location by Id
        public Task<Localizacion> getLocationByCode(int codeLocation)
        {
            return database.Table<Localizacion>()
                .Where(i => i.id == codeLocation)
                .FirstOrDefaultAsync();
        }

        // Create or Update Location
        public Task<int> saveLocation(Localizacion location)
        {
            if(location.id != 0)
            {
                return database.UpdateAsync(location);
            }
            else
            {
                return database.InsertAsync(location);
            }
        }

        // Delete location by Id
        public Task<int> deleteLocation(Localizacion location)
        {
            return database.DeleteAsync(location);
        }
    }
}
