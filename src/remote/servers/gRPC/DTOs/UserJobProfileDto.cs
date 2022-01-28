namespace gRPC.DTOs
{
    public class UserJobProfileDto
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public JobPositionDto JobPosition { get; set; }
        public TechnologyDto Technology { get; set; }
        public LevelDto Level { get; set; }
    }
}