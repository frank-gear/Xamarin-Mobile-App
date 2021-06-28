using SQLite;
using C971FrankHaltom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C971FrankHaltom.Services
{
    public interface ILocalDataService
    {
        void Initialize();
    }
    public class SqlLiteDatabaseService : ILocalDataService
    {
        private SQLiteConnection _database;
        public void Initialize()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),  "TermsAppDb.db3");
                _database = new SQLiteConnection(dbPath);
            }
            _database.CreateTable<CourseClass>();
            _database.CreateTable<TermClass>();

            
        }
    }
}
