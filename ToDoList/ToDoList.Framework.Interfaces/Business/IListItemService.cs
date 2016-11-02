using System.Collections.Generic;
using ToDoList.Framework.Data;

namespace ToDoList.Framework.Interfaces.Business
{
    public interface IListItemService
    {
        IEnumerable<ListItem> GetListItems();
        int CreateListItem(ListItem item);
        void UpdateListItem(int id, ListItem item);
        void DeleteListItem(int id);
    }
}
