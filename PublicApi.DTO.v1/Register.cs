//using Domain.App;

namespace PublicApi.DTO.v1
{
    public class Register
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string AccountType { get; set; } = default!;
    }
}