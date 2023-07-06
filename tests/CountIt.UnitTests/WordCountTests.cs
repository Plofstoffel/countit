using CountIt.Models;

namespace CountIt.UnitTests
{
	[TestClass]
	public class WordCountTests
	{
		[DataTestMethod]
		[DataRow("true")]
		[DataRow("False")]
		public void WhenWordCounterIsCreated_TheWordPropertyShouldBeLowerCase(string word)
		{
			//Arrange
			var wordCount = new WordCount(word);

			//Assert
			Assert.AreEqual(word.ToLower(), wordCount.Word);
			Assert.AreEqual(0, wordCount.Count);
		}
	}
}
