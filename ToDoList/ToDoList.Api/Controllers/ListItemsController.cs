using System.Linq;
using System.Web.Http;
using ToDoList.Api.Models;
using System.Threading.Tasks;
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
            if (model == null) return BadRequest();

            var result = await _repository.Insert(new CreateListItemDTO { Content = model.Content });

            return Created($"/api/listItems/{result}", new { Id = result });
        }

        [HttpPut,
        Route("api/listitems/{id}/iscomplete")]
        public async Task<IHttpActionResult> ChangeListItemStatus([FromUri] int id, ChangeListItemStatusModel model)
        {
            if (model == null || id < 1) return BadRequest();

            var result = await _repository.UpdateStatus(id, model.IsComplete);
            
            if (!result) return NotFound();

            return Ok();
        }

        [HttpPut,
        Route("api/listitems/{id}/content")]
        public async Task<IHttpActionResult> ChangeListItemContent([FromUri] int id, ChangeListItemContentModel model)
        {
            if (model == null || id < 1) return BadRequest();

            var result = await _repository.UpdateContent(id, model.Content);

            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete,
        Route("api/listitems/{id}")]
        public async Task<IHttpActionResult> DeleteListItem([FromUri] int id)
        {
            if (id < 1) return BadRequest();

            var result = await _repository.Remove(id);

            if (!result) return NotFound();

            return Ok();
        }
    }
}
