namespace RestAssuredNetExamples
{
    using NUnit.Framework;
    using static RestAssured.Dsl;

    public class ParameterizedTests
    {
        [Test]
        public void QueryParameterExample()
        {
            Given()
            .QueryParam("text", "RestAssured.Net")
            .When()
            .Get("http://md5.jsontest.com")
            .Then()
            .Body("$.original", NHamcrest.Is.EqualTo("RestAssured.Net"))
            .Body("$.md5", NHamcrest.Is.EqualTo("3d0761128d4c535dd4ee69b54abde303"));
        }

        [Test]
        public void PathParameterExample()
        {
            Given()
            .PathParam("countryCode", "us")
            .PathParam("zipCode", 90210)
            .When()
            .Get("http://api.zippopotam.us/{{countryCode}}/{{zipCode}}")
            .Then()
            .Body("$.places[0].['place name']", NHamcrest.Is.EqualTo("Beverly Hills"));
        }

        [TestCase("us", 90210, "Beverly Hills", TestName = "US zip code 90210 maps to Beverly Hills")]
        [TestCase("ca", "Y1A", "Whitehorse", TestName = "CA zip code Y1A maps to Whitehorse")]
        [TestCase("it", 50123, "Firenze", TestName = "IT zip code 50123 maps to Firenze")]
        public void ParameterizedTestExample(string countryCode, object zipCode, string expectedPlace)
        {
            Given()
            .PathParam("countryCode", countryCode)
            .PathParam("zipCode", zipCode)
            .When()
            .Get("http://api.zippopotam.us/{{countryCode}}/{{zipCode}}")
            .Then()
            .Body("$.places[0].['place name']", NHamcrest.Is.EqualTo(expectedPlace));
        }
    }
}