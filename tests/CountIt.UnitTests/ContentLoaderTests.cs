using CountIt.Logic;
using Moq;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace CountIt.UnitTests
{
	[TestClass]
	public class ContentLoaderTests
	{
		private const string _content = "Some test text.";

		[TestMethod]
		public async Task WhenCreatingAContentLoader_TheAsyncContentIsReturned()
		{
			//Arrange
			var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
			{
				{ @"c:\test.txt", new MockFileData(_content) }
			});
			var fileContentLoader = new FileContentLoader(fileSystem);

			//Act
			string content = await fileContentLoader.LoadContent("c:\\", "test.txt");

			//Assert
			Assert.AreEqual(_content, content);
		}

		[TestMethod]
		public async Task WhenCreatingAContentLoaderAndCannotReadFile_ThrowContentException()
		{
			//Arrange
			var fileSystem = Mock.Of<IFileSystem>();
			Mock.Get(fileSystem).Setup(f => f.File.ReadAllTextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ThrowsAsync(new IOException())
				.Verifiable();
			var fileContentLoader = new FileContentLoader(fileSystem);

			//Act
			string content = await fileContentLoader.LoadContent("c:\\", "test.txt");

			//Assert
			Assert.AreEqual(String.Empty, content);
			Mock.VerifyAll();
		}

		[TestMethod]
		public async Task WhenCreatingAContentLoaderAndCannotFindFile_ThrowFileNotFoundException()
		{
			//Arrange
			var fileSystem = Mock.Of<IFileSystem>();
			Mock.Get(fileSystem).Setup(f => f.File.ReadAllTextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ThrowsAsync(new FileNotFoundException())
				.Verifiable();
			var fileContentLoader = new FileContentLoader(fileSystem);

			//Act
			string content = await fileContentLoader.LoadContent("c:\\", "test.txt");

			//Assert
			Assert.AreEqual(String.Empty, content);
			Mock.VerifyAll();
		}

		[TestMethod]
		public async Task WhenCreatingAContentLoaderAndCannotFindDirectory_ThrowDirectoryNotFoundException()
		{
			//Arrange
			var fileSystem = Mock.Of<IFileSystem>();
			Mock.Get(fileSystem).Setup(f => f.File.ReadAllTextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ThrowsAsync(new DirectoryNotFoundException())
				.Verifiable();
			var fileContentLoader = new FileContentLoader(fileSystem);

			//Act
			string content = await fileContentLoader.LoadContent("c:\\", "test.txt");

			//Assert
			Assert.AreEqual(String.Empty, content);
			Mock.VerifyAll();
		}

		[TestMethod]
		public void WhenCreatingAContentLoaderWithNullFileSystem_Throws()
		{
			//Arrange and Act and Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			Assert.ThrowsException<ArgumentNullException>(() => new FileContentLoader(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		}
	}
}
