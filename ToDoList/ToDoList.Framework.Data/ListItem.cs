using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Framework.Data
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
