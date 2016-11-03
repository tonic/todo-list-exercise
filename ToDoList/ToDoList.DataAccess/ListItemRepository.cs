using System;
using System.Collections.Generic;
using ToDoList.Framework.Data;
using ToDoList.Framework.Interfaces.DataAccess;

namespace ToDoList.DataAccess
{
    public class ListItemRepository : IListItemRepository
    {
        private readonly string _connectionString;

        private const string GetAllQuery = @"SELECT [Id], [Content], [IsComplete] from [Todo].[ListItems]";
        private const string InsertCommand = @"INSERT INTO [ToDo].[ListItems] VALUES (@Content)";
        private const string RemoveCommand = @"DELETE FROM [ToDo].[ListItems] WHERE [Id] = @Id";
        private const string UpdateStatusCommand = @"UPDATE [ToDo].[ListItems] SET [IsComplete] = @IsComplete WHERE [Id] = @Id";
        private const string UpdateContentCommand = @"UPDATE [ToDo].[ListItems] SET [Content] = @Content WHERE [Id] = @Id";

        public ListItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ListItem> Find()
        {
            throw new NotImplementedException();
        }

        public int Insert(ListItem item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContent(int id, string content)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatus(int id, bool isComplete)
        {
            throw new NotImplementedException();
        }
    }
}
