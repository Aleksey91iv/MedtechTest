using Contracts;
using IInfrastructure;
using Models;
using Moq;
using TestViewer;
using ViewModels.IServices;
using ViewModels.Services;

namespace UnitTest
{
    public class Tests
    {
        [Test]
        public void AddWithInCorrectArgument()
        {
            Mock<IDateTimeManagerBuilder> dateTimeManagerBuilderMock = new Mock<IDateTimeManagerBuilder>();
            Mock<IDateTimeMapper> dateTimeMapperMock = new Mock<IDateTimeMapper>();
            Mock<IActionRouteService> actionRouteServiceToUIThreadMock = new Mock<IActionRouteService>();

            MessageViewer messageViewer = new MessageViewer(dateTimeManagerBuilderMock.Object, dateTimeMapperMock.Object);

            int preCount = messageViewer.DateTimeDescriptions.Count;

            Assert.DoesNotThrow(() =>
            {
                messageViewer.Add(null);
            });

            int postCount = messageViewer.DateTimeDescriptions.Count;

            Assert.That(postCount, Is.EqualTo(preCount));
        }

        [Test]
        public void AddCorrect()
        {
            Mock<IDateTimeManagerBuilder> dateTimeManagerBuilderMock = new Mock<IDateTimeManagerBuilder>();
            Mock<IActionRouteService> actionRouteServiceToUIThreadMock = new Mock<IActionRouteService>();

            IDateTimeMapper dateTimeMapper = new DateTimeMapper();

            MessageViewer messageViewer = new MessageViewer(dateTimeManagerBuilderMock.Object, dateTimeMapper);

            DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.GetSystemTimeZones()[83]);
            DateTimeInternalFormat dateTimeDescription = new DateTimeInternalFormat(dateTime, TimeZoneInfo.GetSystemTimeZones()[83], "Самарское время");

            int preCount = messageViewer.DateTimeDescriptions.Count;

            Assert.DoesNotThrow(() =>
            {
                messageViewer.Add(dateTimeDescription);
            });

            int postCount = messageViewer.DateTimeDescriptions.Count;

            Assert.That(postCount, Is.EqualTo(preCount + 1));
        }
    }
}