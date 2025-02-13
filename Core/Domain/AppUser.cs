namespace UdemyJwtApp.BackOffice.Core.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AppRoleID { get; set; }
        public AppRole AppRole { get; set; }

        public AppUser() { 

        AppRole = new AppRole();

        }
    }
}
