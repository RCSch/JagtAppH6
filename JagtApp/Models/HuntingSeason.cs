using System;
using System.Text.Json.Serialization;

namespace JagtApp.Models
{
    public class HuntingSeason
    {
        public int Id { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }

        public int GameAnimalId { get; set; }

        [JsonIgnore]
        public GameAnimal GameAnimal { get; set; }

        public HuntingSeason(int huntingSeasonId, int startMonth, int startDay, int endMonth, int endDay)
        {
            Id = huntingSeasonId;
            StartMonth = startMonth;
            StartDay = startDay;
            EndMonth = endMonth;
            EndDay = endDay;
        }

        public HuntingSeason() { }

        // Helper methods to get the DateTime for the current year
        public DateTime GetStartDate(int year)
        {
            return new DateTime(year, StartMonth, StartDay);
        }

        public DateTime GetEndDate(int year)
        {
            return new DateTime(year, EndMonth, EndDay);
        }

        public bool IsInSeason(DateTime date)
        {
            if (StartMonth < EndMonth)
            {
                return date.Month > StartMonth || (date.Month == StartMonth && date.Day >= StartDay)
                    && date.Month < EndMonth || (date.Month == EndMonth && date.Day <= EndDay);
            }
            else if (StartMonth > EndMonth)
            {
                return date.Month > StartMonth || (date.Month == StartMonth && date.Day >= StartDay)
                    || date.Month < EndMonth || (date.Month == EndMonth && date.Day <= EndDay);
            }
            return false;
        }
    }
}
