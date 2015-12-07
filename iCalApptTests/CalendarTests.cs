using System;
using NUnit.Framework;
using iCalApp;

namespace iCalApptTests
{
    public class CalendarTests
    {
        [Test]
        public void GivenAnCalendar_WhenAddingAnEvent_ThenTheicsTextIsCorrect()
        {
            var calendar = new Calendar();
            var when = DateTime.Today;
            const string eventDescription = "ShipIt";
            Assert.That(calendar.CreateEvent(when, eventDescription), Is.EqualTo("aaaaaaaaa"));
        }
    }
}
