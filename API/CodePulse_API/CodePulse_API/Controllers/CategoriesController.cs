using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodePulse_API.Models.DTO;
using CodePulse_API.Models.Domain;
using Microsoft.Identity.Client;
using CodePulse_API.Data;
using CodePulse_API.Repositories.Interface;

namespace CodePulse_API.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ////3) Creamos un private fiel 
        //private readonly ApplicationDbContext dbContext;


        ////2) Creamos un constructor con la inyección del dbcontenxt
        //public CategoriesController(ApplicationDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        // 6) cambiamos 2 y 3 por el uso del repository pattern
        
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository) { 
            this.categoryRepository = categoryRepository;
            this.categoryRepository = categoryRepository;
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

            //7) implmenetamos el método de category

            await categoryRepository.CreateAsync(category); // con esta línea básicamente estamos abstrayendo la implmentacion del repositorio y el controlador no tiene idea como el repositorio se comunica y salva los cambios en la db 

            
            //4) (esto termina siendo una mala práctica -> al hacerlo en el controller, por eso conviene hacerlo en el repository
            //await dbContext.Categories.AddAsync(category);
            //await dbContext.SaveChangesAsync();

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
