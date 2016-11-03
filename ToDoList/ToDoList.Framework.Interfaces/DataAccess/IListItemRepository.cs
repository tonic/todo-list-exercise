using System.Collections.Generic;
using ToDoList.Framework.Data;

namespace ToDoList.Framework.Interfaces.DataAccess
{
    public interface IListItemRepository
    {
        IEnumerable<ListItem> Find();
        int Insert(ListItem item);
        bool Remove(int id);
        bool UpdateStatus(int id, bool isComplete);
        bool UpdateContent(int id, string content);
    }
}
