namespace MartianRobots.Test
{
    using MartianRobots.Web;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Net.Http.Headers;
    using Microsoft.OpenApi.Readers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestClass]
    public class WebTests
    {
        private static WebApplicationFactory<Startup> factory;
        private static HttpClient client;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            client.Dispose();
            factory.Dispose();
        }

        [TestMethod]
        public async Task OpenApi_document_is_valid()
        {
            using (var response = await client.GetAsync($"/openapi.json"))
            {
                var reader = new OpenApiStreamReader();

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    reader.Read(stream, out var diagnostic);
                    var condition = diagnostic.Errors.Any();

                    Assert.IsFalse(condition, string.Join(",", diagnostic.Errors));
                }
            }
        }

        [TestMethod]
        public async Task SwaggerUI_works()
        {
            var value = await client.GetStringAsync("/openapi");

            StringAssert.Contains(value, "SwaggerUIBundle");
        }

        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public async Task Api_Get_works(string input, string expected)
        {
            var world = WebUtility.UrlEncode(input);

            var actual = await client.GetStringAsync($"/api?world={world}");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public async Task Api_Post_parameters_works(string input, string expected)
        {
            var parameters = new Dictionary<string, string>
            {
                ["world"] = input
            };

            using (var content = new FormUrlEncodedContent(parameters))
            {
                using (var response = await client.PostAsync("/api", content))
                {
                    var actual = await response.Content.ReadAsStringAsync();

                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public async Task Api_Post_entity_works(string input, string expected)
        {
            using (var content = new StringContent(input))
            {
                using (var response = await client.PostAsync("/api/entity", content))
                {
                    var actual = await response.Content.ReadAsStringAsync();

                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public async Task Api_Bad_data_throws()
        {
            const string input = @"1 1
0 0 W
X";

            using (var content = new StringContent(input))
            {
                using (var response = await client.PostAsync("/api/entity", content))
                {
                    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                }
            }
        }

        [TestMethod]
        public async Task Form_Get_works()
        {
            using (var response = await client.GetAsync("/"))
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        [DynamicData(nameof(Test.Data), typeof(Test))]
        public async Task Form_Post_works(string input, string expected)
        {
            var parameters = new Dictionary<string, string>
            {
                ["world"] = input
            };

            using (var content = new FormUrlEncodedContent(parameters))
            {
                using (var response = await client.PostAsync("/", content))
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var value = WebUtility.HtmlDecode(body);

                    StringAssert.Contains(value, expected);
                }
            }
        }

        [TestMethod]
        public async Task Form_bad_data_throws()
        {
            const string input = @"1 1
0 0 W
X";

            var parameters = new Dictionary<string, string>
            {
                ["world"] = input
            };

            using (var content = new FormUrlEncodedContent(parameters))
            {
                using (var response = await client.PostAsync("/", content))
                {
                    var value = await response.Content.ReadAsStringAsync();

                    StringAssert.Contains(value, "<span class=\"error\">");
                }
            }
        }

        [TestMethod]
        public async Task Sends_CORS_headers()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Options, "/"))
            {
                request.Headers.Add(HeaderNames.Origin, "example.com");
                request.Headers.Add(HeaderNames.AccessControlRequestHeaders, HeaderNames.ContentType);
                request.Headers.Add(HeaderNames.AccessControlRequestMethod, HttpMethods.Post);

                using (var response = await client.SendAsync(request))
                {
                    var exists = response.Headers.TryGetValues(HeaderNames.AccessControlAllowOrigin, out var values);
                    Assert.IsTrue(exists);
                    Assert.IsTrue(values.Contains("*"));

                    exists = response.Headers.TryGetValues(HeaderNames.AccessControlAllowHeaders, out values);
                    Assert.IsTrue(exists);
                    Assert.IsTrue(values.Contains(HeaderNames.ContentType));

                    exists = response.Headers.TryGetValues(HeaderNames.AccessControlAllowMethods, out values);
                    Assert.IsTrue(exists);
                    Assert.IsTrue(values.Contains(HttpMethods.Post));
                }
            }
        }

        [TestMethod]
        public async Task Handles_head_requests()
        {
            using (var message = new HttpRequestMessage(HttpMethod.Head, "/api"))
            {
                using (var response = await client.SendAsync(message))
                {
                    Assert.IsTrue(response.IsSuccessStatusCode);
                }
            }
        }
    }
}
