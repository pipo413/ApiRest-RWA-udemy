using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodePulse_API.Models.DTO;
using CodePulse_API.Models.Domain;
using Microsoft.Identity.Client;
using CodePulse_API.Data;

namespace CodePulse_API.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //3) Creamos un private fiel 
        private readonly ApplicationDbContext dbContext;


        //2) Creamos un constructor con la inyección del dbcontenxt
        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO request)
        {


            // 1)Aca hacemos un MAP a DTO y lo pasamos domain model

            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
            
            //4)
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            // domain model to DTO

            // 5) Creamos dentro de DTO la CategotyDTO con los elementos que nos va a requerir el usuario (Angular) luego 

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

        }
    }
}
