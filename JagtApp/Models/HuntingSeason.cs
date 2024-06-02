namespace JagtApp.Models
{
    public class HuntingSeason
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public HuntingSeason(int huntingSeasonId, DateTime startDate, DateTime endDate)
        {
            Id = huntingSeasonId;
            StartDate = startDate;
            EndDate = endDate;
        }
        public HuntingSeason() { }
    }
}
