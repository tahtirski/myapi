using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using myapi.Controllers;
using myapi.DAL;
using myapi.Models;
using Xunit;

namespace myapi_test
{
    public class ControllerTest
    {

        [Fact]
        public void test_WriteToDatabase()
        {
            using var connection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");
            connection.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            using var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            var repo = new SqlLiteRepository(context);
            var controller = new HomeController(repo);

            IActionResult response = controller.WriteToDatabase();
            OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);
            Assert.Equal("Hello World is written to the database.", objectResponse.Value);
        }

        [Fact]
        public void test_WriteToConsole()
        {
            using var connection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");
            connection.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            using var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            var repo = new SqlLiteRepository(context);
            var controller = new HomeController(repo);

            IActionResult response = controller.WriteToConsole();
            OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);
            Assert.Equal("Console app is triggered. 'Hello World' is printed.", objectResponse.Value);
        }
    }
}
