namespace Models
{
    public class UserAuthVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string email { get; set; } = string.Empty;
        public bool KeepLoggedIn { get; set; }
    }
}
