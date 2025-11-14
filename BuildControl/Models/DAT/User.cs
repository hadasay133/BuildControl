using BuildControl.models.DAT;

namespace BuildControl.Models.DAT
{
    public class User
    {
      

            public int UserId { get; set; }
            public required string FirstName { get; set; }
            public required string FamilyName { get; set; }
            public required int UserType { get; set; }

            public List<WorkSite> WorkSites { get; set; }
            public required string Password { get; set; }
    }
   
}
