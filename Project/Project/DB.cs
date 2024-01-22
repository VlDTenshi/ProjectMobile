using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class DB
    {
        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Item>();
        }
        public List<Item> GetItems()
        {
            return conn.Table<Item>().ToList();
        }
        public int SaveItem(Item item)
        {
            return conn.Insert(item);
        }
        public int DeleteItem(Item item)
        {
            return conn.Delete(item);
        }
    }
}
