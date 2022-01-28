using System.Collections.Generic;

namespace Application.DTOs
{
    public class UserProfiles
    {
        public int UserId { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}