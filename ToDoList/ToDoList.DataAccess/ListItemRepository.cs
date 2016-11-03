using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Framework.Data;
using ToDoList.Framework.Interfaces.DataAccess;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ToDoList.DataAccess
{
    public class ListItemRepository : IListItemRepository
    {
        private readonly string _connectionString;

        private const string GetAllQuery = @"SELECT [Id], [Content], [IsComplete] from [ToDo].[ListItem]";
        private const string InsertCommand = @"INSERT INTO [ToDo].[ListItem] ([Content]) OUTPUT Inserted.Id VALUES (@Content)";
        private const string RemoveCommand = @"DELETE FROM [ToDo].[ListItem] WHERE [Id] = @Id";
        private const string UpdateStatusCommand = @"UPDATE [ToDo].[ListItem] SET [IsComplete] = @IsComplete WHERE [Id] = @Id";
        private const string UpdateContentCommand = @"UPDATE [ToDo].[ListItem] SET [Content] = @Content WHERE [Id] = @Id";

        public ListItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ListItem>> Find()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<ListItem>(GetAllQuery);
            }
        }

        public async Task<int> Insert(CreateListItemDTO item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<int>(InsertCommand, item);

                return result.Any() ? result.Single() : 0;
            }
        }

        public async Task<bool> Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(RemoveCommand, new { Id = id });

                return result == 1;
            }
        }

        public async Task<bool> UpdateContent(int id, string content)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(UpdateContentCommand, new { Id = id, Content = content });

                return result == 1;
            }
        }

        public async Task<bool> UpdateStatus(int id, bool isComplete)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteAsync(UpdateStatusCommand, new { Id = id, IsComplete = isComplete });

                return result == 1;
            }
        }
    }
}
