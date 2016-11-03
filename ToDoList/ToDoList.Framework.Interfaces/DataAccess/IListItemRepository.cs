using System.Collections.Generic;
using ToDoList.Framework.Data;
using System.Threading.Tasks;

namespace ToDoList.Framework.Interfaces.DataAccess
{
    public interface IListItemRepository
    {
        Task<IEnumerable<ListItem>> Find();
        Task<int> Insert(CreateListItemDTO item);
        Task<bool> Remove(int id);
        Task<bool> UpdateStatus(int id, bool isComplete);
        Task<bool> UpdateContent(int id, string content);
    }
}
