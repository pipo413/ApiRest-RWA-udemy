namespace CodePulse_API.Models.DTO
{
    public class CategoryDTO
    {
        // toda la infomación requerida por el usuario angular aplication) 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
