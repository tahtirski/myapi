using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapi.Models
{
    
    public class HelloWorld
    {
        public HelloWorld() {} 
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
