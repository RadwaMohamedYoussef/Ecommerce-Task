using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Application.IService;
using E_Commerce.Application.DTO;
namespace E_Commerce.API.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost("add")]
        public IActionResult AddStore([FromForm] StoreDto storeDto)
        {
            _storeService.AddStore(storeDto);
            return Ok("Store added successfully.");
        }

        [HttpDelete("remove/{id}")]
        public IActionResult RemoveStore(int id)
        {
            _storeService.RemoveStore(id);
            return Ok("Store removed successfully.");
        }
    }
}
