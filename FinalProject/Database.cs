using System;
using System.Collections.Generic;
using System.IO;
using FinalProject.Models;
using SQLite;

namespace FinalProject
{
    public class Database
    {
        SQLiteConnection database = null;

        public Database()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "final_project.db3");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Favorite>();
        }

        public void InsertFavorite(Favorite favorite)
        {
            database.InsertOrReplace(favorite);
        }

        public void DeleteFavorite(string favoriteId)
        {
            database.Delete<Favorite>(favoriteId);
        }

        public bool CheckIsFavorite(string favoriteId)
        {
            return database.Query<Favorite>("select * from favorite where id", favoriteId).Count > 0;
        }

        public List<Favorite> GetFavorite()
        {
            return database.Table<Favorite>().ToList();
        }
    }
}
