namespace Eshop.Entities
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public int? Role {  get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public int? Id { get; set; }

        public UserInfo(bool isAuthenticated, int? role, string? fullName, string? email,int? id)
        {
            IsAuthenticated = isAuthenticated;
            Role = role;
            FullName = fullName;
            Email = email;
            Id = id;
        }
    }
}
