using Microsoft.AspNetCore.Mvc;
using NTierApplication.Repository;
using NTierApplication.Service;
using NTierApplication.Service.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace NTierApplication.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService ItemService;

        public ItemController(IItemService itemService)
        {
            ItemService = itemService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerOperation(OperationId = "GetAll")]
        public ICollection<ItemViewModel> GetAll()
        {
            return ItemService.GetItems();
        }

        [HttpPost(Name = "CreateNew")]
        public ItemViewModel CreateNew(ItemViewModel itemViewModel)
        {
            ItemService.CreateNew(itemViewModel);
            return itemViewModel;
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(OperationId = "GetById")]
        public ItemViewModel GetById(long id)
        {
            return ItemService.GetById(id);
        }

        [HttpDelete]
        [Route("Delete:{id}")]
        public ItemViewModel Delete(long id)
        {
            var item = ItemService.GetById(id);
            ItemService.Delete(id);
            return item;
        }

        [HttpPut]
        [Route("Update")]
        public ItemViewModel Update(ItemViewModel item)
        {
            ItemService.Update(item);
            return item;
        }
    }
}
