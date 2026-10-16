namespace RaceDayApi.DTOs
{
    public class CreateResultDto
    {
        public int EnrolmentId { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int FinishingPosition { get; set; }
    }
}
