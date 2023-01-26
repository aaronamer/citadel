using Citadel.Controllers;
using Citadel.Data;
using Citadel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Citadel.Tests
{
    [TestClass]
    public class NamesRepositoryTests
    {
        [TestMethod]
        public async Task Ensure_NamesRepository_Adds_Name_To_DbContext()
        {
            const string name = "Aaron";

            var repository = new Mock<Repository>(); 
            repository.Setup(x => x.Names.Add(It.IsAny<NameModel>()));
            repository.Setup(x => x.SaveChangesAsync(default));

            var namesRespository = new NamesRepository(repository.Object);
            await namesRespository.Add(name);
            
            repository.Verify(x => x.Names.Add(It.Is<NameModel>(p => p.Name.Equals(name))));
            repository.Verify(x => x.SaveChangesAsync(default));
        }
    }
}
