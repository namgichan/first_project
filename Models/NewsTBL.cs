namespace WebApplication1.Models
{
    public class NewsTBL
    {
        public int NewsNum { get; set; }
        public string? NewsArea { get; set; }
        public string? NewsTitle { get; set;}
        public string? NewsCont { get; set; }
        public DateTime? NewsPreDate { get; set; }
        public int Hits { get; set; }
        public string? UserID { get; set; }
    }
}
