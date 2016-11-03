using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Api.Models;
using System.Threading.Tasks;
using ToDoList.DataAccess;
using ToDoList.Framework.Interfaces.DataAccess;
using ToDoList.Framework.Data;

namespace ToDoList.Api.Controllers
{
    public class ListItemsController : ApiController
    {
        private readonly IListItemRepository _repository;

        public ListItemsController(IListItemRepository repository)  // normally I would create a business layer on top of the DAL and inject it here instead (e.g. IListItemService), but this app has no business logic.
        {
            _repository = repository;
        }

        [HttpGet,
        Route("api/listitems")]
        public async Task<IHttpActionResult> GetListItems()
        {
            var result = await _repository.Find();

            return Ok(result.Select(i => new ListItemModel { Id = i.Id, Content = i.Content, IsComplete = i.IsComplete }).ToArray());
        }

        [HttpPost,
        Route("api/listitems")]
        public async Task<IHttpActionResult> CreateListItem(CreateListItemModel model)
        {
            var result = await _repository.Insert(new CreateListItemDTO { Content = model.Content });

            return Created($"/api/listItems/{result}", new { Id = result });
        }

        [HttpPut,
        Route("api/listitems/{id}/iscomplete")]
        public async Task<IHttpActionResult> ChangeListItemStatus([FromUri] int id, ChangeListItemStatusModel model)
        {
            var result = await _repository.UpdateStatus(id, model.IsComplete);
            
            if (!result) return NotFound();

            return Ok();
        }

        [HttpPut,
        Route("api/listitems/{id}/content")]
        public async Task<IHttpActionResult> ChangeListItemContent([FromUri] int id, ChangeListItemContentModel model)
        {
            var result = await _repository.UpdateContent(id, model.Content);

            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete,
        Route("api/listitems/{id}")]
        public async Task<IHttpActionResult> DeleteListItem([FromUri] int id)
        {
            var result = await _repository.Remove(id);

            if (!result) return NotFound();

            return Ok();
        }
    }
}
