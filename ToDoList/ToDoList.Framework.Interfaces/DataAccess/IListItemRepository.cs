using System.Collections.Generic;
using ToDoList.Framework.Data;

namespace ToDoList.Framework.Interfaces.DataAccess
{
    public interface IListItemRepository
    {
        IEnumerable<ListItem> Find();
        int Insert(ListItem item);
        void Remove(int id);
        void Update(ListItem item);
    }
}
