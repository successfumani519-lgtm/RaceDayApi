namespace RaceDayApi.DTOs
{
    public class UserProfileDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } // Maps to Organiser.ContactPhone or ignored for Participants
    }
}
