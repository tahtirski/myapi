using System;
using System.Linq;
using myapi.Models;
namespace myapi.DAL
{
    public class SqlLiteRepository:IRepository
    {
        private readonly AppDbContext _db;
        public SqlLiteRepository(AppDbContext db)
        {
            _db = db;
        }

        public HelloWorld ReadFromDb()
        {
            return _db.HelloWorld.FirstOrDefault();
        }

        public int WriteToDb()
        {
            _db.HelloWorld.Add(new HelloWorld() { Text = "Hello World" });
            return _db.SaveChanges(); 
        }
    }
}
