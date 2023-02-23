
namespace FinalProject.Application.DTOs.User
{
    public class UserQueryDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
