namespace task5.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string StudentEmail { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}