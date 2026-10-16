namespace RaceDayApi.DTOs
{
    public class CreateEventDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }

    public class UpdateEventDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }
}
