using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Api.Models;
using System.Threading.Tasks;

namespace ToDoList.Api.Controllers
{
    public class ListItemsController : ApiController
    {
        [HttpGet,
        Route("api/listitems")]
        public async Task<IEnumerable<ListItemModel>> GetListItems()
        {
            return await Task.FromResult(Enumerable.Empty<ListItemModel>());
        }

        [HttpPost,
        Route("api/listitems")]
        public async Task<int> CreateListItem(ListItemModel model)
        {
            return await Task.FromResult(0);
        }

        [HttpPut,
        Route("api/listitems/{id}/iscomplete")]
        public async Task ChangeListItemStatus([FromUri] int id, ChangeListItemStatusModel model)
        {
            return;
        }

        [HttpPut,
        Route("api/listitems/{id}/content")]
        public async Task ChangeListItemContent([FromUri] int id, ChangeListItemContentModel model)
        {
            return;
        }

        [HttpDelete,
        Route("api/listitems/{id}")]
        public async Task DeleteListItem([FromUri] int id)
        {
            return;
        }
    }
}
