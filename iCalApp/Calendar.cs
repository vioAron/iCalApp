using System;
using System.Text;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace iCalApp
{
    public class Calendar
    {
        public ICSData GetICSFile(DateTime start, DateTime end, string location, string title, string summary,
            string organizer)
        {
            var icsData = new ICSData();

            if (!ValidateICSFile(icsData, start, end, location, title, organizer))
            {
                return icsData;
            }

            var calendar = new iCalendar();
            var @event = new Event
            {
                Start = new iCalDateTime(end),
                End = new iCalDateTime(end),
                Location = location,
                Summary = summary,
                Organizer = new Organizer(organizer)
            };

            calendar.Events.Add(@event);

            icsData.ICSFile = new iCalendarSerializer().SerializeToString(calendar);

            return icsData;
        }

        private static bool ValidateICSFile(ICSData icsData, DateTime start, DateTime end, string location, string title, string organizer)
        {
            var errors = new StringBuilder();
            if (start > end)
                errors.AppendLine("Please provide a valid start/end!");
            if (string.IsNullOrEmpty(location))
                errors.AppendLine("Please provide a valid location!");
            if (string.IsNullOrEmpty(title))
                errors.AppendLine("Please provide a valid title!");
            if (string.IsNullOrEmpty(organizer))
                errors.AppendLine("Please provide a valid organizer!");

            icsData.IsValid = errors.Length == 0;
            if (errors.Length > 0)
            {
                icsData.ErrorText = errors.ToString().TrimEnd();
            }

            return icsData.IsValid;
        }
    }
}
