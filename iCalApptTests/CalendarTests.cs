using System;
using NUnit.Framework;
using iCalApp;

namespace iCalApptTests
{
    public class CalendarTests
    {
        [Test]
        public void GivenAnCalendar_WhenGetICSFileWithCorrectArguments_ThenTheICSDataIsValidAndICSFileTextIsCorrect()
        {
            var calendar = new Calendar();
            var expectedICSData = new ICSData
            {
                IsValid = true,
                ErrorText = null,
            };
            var icsFile = calendar.GetICSFile(new DateTime(2015, 9, 15), new DateTime(2015, 9, 16), "Cluj", "ShipIt",
                "ShipIt IT contest", "Vio");

            Assert.That(icsFile, Is.EqualTo(expectedICSData).Using(new ICSDataEqualityComparer()));
            Assert.That(icsFile.ICSFile, Is.Not.Empty);
        }

        [Test]
        public void GivenAnCalendar_WhenGetICSFileWithIncorrectArguments_ThenTheICSDataIsNotValidAndErrorsAreWritten()
        {
            var calendar = new Calendar();
            var expectedICSData = new ICSData
            {
                IsValid = false,
                ErrorText =
@"Please provide a valid start/end!
Please provide a valid location!
Please provide a valid title!
Please provide a valid organizer!"
            };
            Assert.That(calendar.GetICSFile(DateTime.MaxValue, DateTime.MinValue, null, string.Empty, null, string.Empty),
                Is.EqualTo(expectedICSData).Using(new ICSDataEqualityComparer()));
        }
    }
}
