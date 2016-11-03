using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Models
{
    public class ChangeListItemStatusModel
    {
        [Required]
        public bool IsComplete { get; set; }
    }
}
