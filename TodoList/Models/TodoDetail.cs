using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TodoDetail
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public bool Isdone { get; set; }

        public virtual ApplicationUser User { get; set; }
             
    }
}