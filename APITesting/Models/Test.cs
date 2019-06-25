using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITesting.Models
{
    public class Test
    {
        public bool Completed { get; set; }

        public DateTime DueDate { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }

    }
}