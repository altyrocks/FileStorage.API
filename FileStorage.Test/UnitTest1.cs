using FileStorage.API.Controllers;
using FileStorage.API.Repository;
using Moq;

namespace FileStorage.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IFileRepository> mockRepository;
        private FileController mockController;

        [TestMethod]
        public void TestMethod1()
        {
            mockRepository = new Mock<IFileRepository>();
            mockController = new FileController(mockRepository.Object);

            var result = mockController.GetAllFiles();

            Assert.IsNotNull(result);
        }
    }
}