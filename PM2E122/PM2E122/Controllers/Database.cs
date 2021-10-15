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

            database.CreateTableAsync<Location>().Wait();
        }

        // CRUD Operations with SQLite

        // Get Location List
        public Task<List<Location>> getListLocations()
        {
            return database.Table<Location>().ToListAsync();
        }


        // Get Location by Id
        public Task<Location> getLocationByCode(int codeLocation)
        {
            return database.Table<Location>()
                .Where(i => i.id == codeLocation)
                .FirstOrDefaultAsync();
        }

        // Create or Update Location
        public Task<int> saveLocation(Location location)
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
        public Task<int> deleteLocation(Location location)
        {
            return database.DeleteAsync(location);
        }
    }
}
