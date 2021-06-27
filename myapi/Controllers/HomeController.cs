using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using consoleapp = myconsoleapp.Program;
using myapi.DAL;

namespace myapi.Controllers
{
    [ApiController] 
    public class HomeController : ControllerBase
    {
        private readonly IRepository _context;
        public HomeController(IRepository context)
        {
            _context = context;

        }

        [HttpGet("api/console")]
        public IActionResult WriteToConsole()
        {
            try
            {
                consoleapp.Main();
                return Ok("Console app is triggered. 'Hello World' is printed.");

            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet ("api/database")]
        public IActionResult WriteToDatabase()
        {
            try
            {
                _context.WriteToDb();
                var result = _context.ReadFromDb();
                return Ok(result.Text + " is written to the database.");

            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
