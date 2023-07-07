using CountIt.Logic;

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

		[TestMethod]
		public void WhenNullValueIsPassed_ThrowAnException()
		{
			//Arrange and Act and Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			Assert.ThrowsException<ArgumentNullException>(() => new WordCount(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		}
	}
}
