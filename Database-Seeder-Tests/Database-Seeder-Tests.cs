
namespace Database_Seeder_Tests
{
    [TestFixture]
    public class Tests
    {
        private Journey journey;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void JourneyIsValid_ReturnTrue()
        {
            journey = new Journey();
            journey.JourneyID = 1;
            journey.DepartureTime = DateTime.Parse("2021-07-31T23:59:59");
            journey.ReturnTime = DateTime.Parse("2021-08-01T00:09:15");
            journey.DepartureStationID = 113;
            journey.ReturnStationID = 78;
            journey.Distance = 1602;
            journey.Duration = 553;

            bool result = ValidateCsvJourney.ValidateJourney(journey);
            Assert.IsTrue(result, "Journey is valid");
        }

        [Test]
        public void ReturnTimeBeforeDeparture_ReturnFalse()
        {
            journey = new Journey();
            journey.JourneyID = 1;
            journey.DepartureTime = DateTime.Parse("2021-07-31T23:59:59");
            journey.ReturnTime = DateTime.Parse("2021-06-01T00:09:15");
            journey.DepartureStationID = 113;
            journey.ReturnStationID = 78;
            journey.Distance = 1602;
            journey.Duration = 553;

            bool result = ValidateCsvJourney.ValidateJourney(journey);
            Assert.IsFalse(result, "Return time not valid");
        }
    }
}