using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Models
{
    public class CreateListItemModel
    {
        [Required, 
         MaxLength(256, ErrorMessage = "To-do list items can't be longer than 256 characters"), 
         MinLength(1, ErrorMessage = "Cannot save empty to-do list item")]
        public string Content { get; set; }
    }
}
