using BuildControl.models.DTO;

namespace BuildControl.models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string FamilyName { get; set; }
        public required int UserType { get; set; }
        public List<WorkSiteDto> WorkSites { get; set; }
        public required string Password { get; set; }
    }
}
