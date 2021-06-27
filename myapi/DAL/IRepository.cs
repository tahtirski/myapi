using System;
using myapi.Models;

namespace myapi.DAL
{
    public interface IRepository
    {
        int WriteToDb();
        HelloWorld ReadFromDb();
    } 
}
