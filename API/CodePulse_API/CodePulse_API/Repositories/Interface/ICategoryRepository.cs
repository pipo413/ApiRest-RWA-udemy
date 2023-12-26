using CodePulse_API.Models.Domain;

namespace CodePulse_API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        // Creamos la definición de los métodos (no la implementación)
        //Task es un tipo en C# que representa una operación asincrónica. El método está marcado como async, lo que significa que puede realizar operaciones asincrónicas sin bloquear el hilo principal.

        Task<Category> CreateAsync(Category category);
    }
}
