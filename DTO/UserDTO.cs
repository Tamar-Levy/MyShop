namespace DTO
{
    public record UserDTO(string Email, string FirstName, string LastName, List<ListUserDTO> Orders);
    public record ListUserDTO(DateTime OrderDate,int OrderSum);
    public record LoginUserDTO(string Email);
    public record PostUserDTO(string Email, string FirstName, string LastName, string password);
}
