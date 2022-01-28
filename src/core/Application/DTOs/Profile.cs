namespace Application.DTOs
{
    public class Profile
    {
        public int Id { set; get; }
        public Position Position { get; set; }
        public Level Level { get; set; }
        public Technology Technology { get; set; }
    }
}