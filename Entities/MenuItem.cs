namespace WebApplication.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; } // Назва пункту
        public string Url { get; set; }   // Посилання
        public List<MenuItem> Children { get; set; } = new List<MenuItem>(); // Список підпунктів
    }
}
