namespace Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminOrAdminPagination
{
    public class GetAllSystemAdminOrAdminPaginationDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
    }
}
