namespace RestAssuredNetExamples
{
    using NUnit.Framework;
    using static RestAssured.Dsl;

    public class BasicExamples
    {
        [Test]
        public void GetLocationsForUsZipCode90210_CheckStatusCode_ShouldBe200()
        {
            Given()
            .When()
            .Get("http://api.zippopotam.us/us/90210")
            .Then()
            .StatusCode(200);
        }

        [Test]
        public void GetLocationsForUsZipCode90210_LogResponseDetails()
        {
            Given()
            .When()
            .Get("http://api.zippopotam.us/us/90210")
            .Then()
            .Log().All();
        }

        [Test]
        public void GetLocationsForUsZipCode90210_CheckContentTypeHeader_ShouldBeApplicationJson()
        {
            Given()
            .When()
            .Get("http://api.zippopotam.us/us/90210")
            .Then()
            .ContentType("application/json");
        }

        [Test]
        public void GetLocationsForUsZipCode90210_CheckCountry_ShouldBeUnitedStates()
        {
            Given()
            .When()
            .Get("http://api.zippopotam.us/us/90210")
            .Then()
            .Body("$.country", NHamcrest.Is.EqualTo("United States"));
        }

        [Test]
        public void GetLocationsForDeZipCode24848_CheckPlaces_ShouldContainKropp()
        {
            Given()
            .When()
            .Get("http://api.zippopotam.us/de/24848")
            .Then()
            .Body("$.places[*].['place name']", NHamcrest.Has.Item(NHamcrest.Is.EqualTo("Kropp")));
        }
    }
}