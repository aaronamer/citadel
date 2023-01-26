using Citadel.Controllers;
using Citadel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Citadel.Tests
{
    [TestClass]
    public class NamesControllerTests
    {
        private readonly ILogger<NamesController> _logger;

        public NamesControllerTests() 
        {
            var logger = new Mock<ILogger<NamesController>>();
            _logger = logger.Object;
        }

        [TestMethod]
        public async Task Ensure_Null_Name_Returns_Bad_Response()
        {
            var namesRespository = new Mock<INamesRepository>();
            namesRespository.Setup(x => x.Add(It.IsAny<string>()));

            var controller = new NamesController(namesRespository.Object, _logger);

            var response = await controller.Post(new Models.NameModel { Name = null! });
            var badRequestResponse = response as BadRequestObjectResult;

            Assert.IsNotNull(badRequestResponse);
            Assert.AreEqual(400, badRequestResponse.StatusCode);
        }

        [TestMethod]
        public async Task Ensure_Empty_Name_Returns_Bad_Response()
        {
            var namesRespository = new Mock<INamesRepository>();
            namesRespository.Setup(x => x.Add(It.IsAny<string>()));

            var controller = new NamesController(namesRespository.Object, _logger);

            var response = await controller.Post(new Models.NameModel { Name = string.Empty });
            var badRequestResponse = response as BadRequestObjectResult;

            Assert.IsNotNull(badRequestResponse);
            Assert.AreEqual(400, badRequestResponse.StatusCode);
        }

        [TestMethod]
        public async Task Ensure_Whitspace_Name_Returns_Bad_Response()
        {
            var namesRespository = new Mock<INamesRepository>();
            namesRespository.Setup(x => x.Add(It.IsAny<string>()));

            var controller = new NamesController(namesRespository.Object, _logger);

            var response = await controller.Post(new Models.NameModel { Name = "   " });
            var badRequestResponse = response as BadRequestObjectResult;

            Assert.IsNotNull(badRequestResponse);
            Assert.AreEqual(400, badRequestResponse.StatusCode);
        }

        [TestMethod]
        public async Task Ensure_Add_Name_Succeeds_When_Name_Not_Empty()
        {
            const string name = "Aaron";

            var namesRespository = new Mock<INamesRepository>();
            namesRespository.Setup(x => x.Add(It.IsAny<string>()));

            var controller = new NamesController(namesRespository.Object, _logger);

            var response = await controller.Post(new Models.NameModel { Name = name });
            var okResponse = response as OkResult;
            
            Assert.IsNotNull(okResponse);
            Assert.AreEqual(200, okResponse.StatusCode);
            namesRespository.Verify(x => x.Add(It.Is<string>(arg => arg.Equals(name))));
        }
    }
}