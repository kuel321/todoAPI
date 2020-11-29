using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ToDoAPI.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string TodoDescription { get; set; }
    }
}