namespace RestAssuredNetExamples
{
    using NUnit.Framework;
    using RestAssuredNetExamples.Model;
    using static RestAssured.Dsl;

    public class Deserialization
    {
        [Test]
        public void PostNewPostUsingPoco_CheckStatusCode_ShouldBe201()
        {
            Post myNewPost = new Post()
            {
                UserId = 1,
                Title = "My new post title",
                Body = "This is the body of my new post"
            };

            Given()
            .Log().All().And()
            .Body(myNewPost)
            .When()
            .Post("http://jsonplaceholder.typicode.com/posts")
            .Then()
            .StatusCode(201);
        }

        [Test]
        public void PostNewPostUsingAnonymousObject_CheckStatusCode_ShouldBe201()
        {
            var myNewPost = new
            {
                userId = 1,
                title = "My new post title",
                body = "This is the body of my new post"
            };

            Given()
            .Log().All().And()
            .Body(myNewPost)
            .When()
            .Post("http://jsonplaceholder.typicode.com/posts")
            .Then()
            .StatusCode(201);
        }

        [Test]
        public void PostNewPostAsXmlUsingAnonymousObject_CheckStatusCode_ShouldBe201()
        {
            Post myNewPost = new Post()
            {
                UserId = 1,
                Title = "My new post title",
                Body = "This is the body of my new post"
            };

            Given()
            .ContentType("application/xml")
            .Log().All().And()
            .Body(myNewPost)
            .When()
            .Post("http://jsonplaceholder.typicode.com/posts")
            .Then()
            .StatusCode(201);
        }

        [Test]
        public void GetPost_CheckTitle_ShouldBeExpectedValue()
        {
            Post myPost =

            (Post)Given()
            .When()
            .Get("http://jsonplaceholder.typicode.com/posts/1")
            .As(typeof(Post));

            Assert.That(myPost.Title, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        }
    }
}