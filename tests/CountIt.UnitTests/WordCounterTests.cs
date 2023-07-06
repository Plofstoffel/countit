
using CountIt.Interfaces;
using CountIt.Logic;

namespace CountIt.UnitTests
{
	[TestClass]
	public class WordCounterTests
	{			

		[TestMethod]
		public void WhenGivenAString_TheDefaultWordCounter_WithDefaultWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator wordValidator = new DefaultWordValidator();
			IWordCounter wordCounter = new DefaultWordCounter(wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}

		[TestMethod]
		public void WhenGivenAString_TheDefaultWordCounter_WithLinqWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator wordValidator = new LinqWordValidator();
			IWordCounter wordCounter = new DefaultWordCounter(wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}

		[TestMethod]
		public void WhenGivenAString_TheDefaultWordCounter_WithRegexWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator wordValidator = new RegexWordValidator();
			IWordCounter wordCounter = new DefaultWordCounter(wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}

		[TestMethod]
		public void WhenGivenAString_TheLinqWordCounter_WithDefaultWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator wordValidator = new DefaultWordValidator();
			IWordCounter wordCounter = new LinqWordCounter(wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}		

		[TestMethod]
		public void WhenGivenAString_TheLinqWordCounter_WithLinqWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator wordValidator = new LinqWordValidator();
			IWordCounter wordCounter = new LinqWordCounter(wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}

		[TestMethod]
		public void WhenGivenAString_TheLinqWordCounter_WithRegexWordValidator_ShouldReturnCorrectCounts()
		{
			// Arrange
			IWordValidator _wordValidator = new RegexWordValidator();
			IWordCounter wordCounter = new LinqWordCounter(_wordValidator);
			string input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

			// Act
			Tuple<WordCount[], int> result = wordCounter.CountIt(input);
			WordCount[] wordCounts = result.Item1;
			int totalWordCount = result.Item2;

			// Assert
			AssertResults(wordCounts, totalWordCount);
		}

		[TestMethod]
		public void WhenDefaultWordCounterIsCreatedWithANullAWordValidator_ThrowsAnException()
		{
			// Arrange and Assert
			Assert.ThrowsException<ArgumentNullException>(()=> new DefaultWordCounter(null));
		}

		[TestMethod]
		public void WhenLinqWordCounterIsCreatedWithoutAWordValidator_ThrowsAnException()
		{
			// Arrange and Assert
			Assert.ThrowsException<ArgumentNullException>(() => new LinqWordCounter(null));
		}

		private static void AssertResults(WordCount[] wordCounts, int totalWordCount)
		{
			Assert.AreEqual(9, wordCounts.Length);

			Assert.AreEqual("big", wordCounts[0].Word);
			Assert.AreEqual(3, wordCounts[0].Count);

			Assert.AreEqual("brown", wordCounts[1].Word);
			Assert.AreEqual(3, wordCounts[1].Count);

			Assert.AreEqual("dog", wordCounts[2].Word);
			Assert.AreEqual(2, wordCounts[2].Count);

			Assert.AreEqual("fox", wordCounts[3].Word);
			Assert.AreEqual(3, wordCounts[3].Count);

			Assert.AreEqual("jumped", wordCounts[4].Word);
			Assert.AreEqual(2, wordCounts[4].Count);

			Assert.AreEqual("lazy", wordCounts[5].Word);
			Assert.AreEqual(2, wordCounts[5].Count);

			Assert.AreEqual("number", wordCounts[6].Word);
			Assert.AreEqual(1, wordCounts[6].Count);

			Assert.AreEqual("over", wordCounts[7].Word);
			Assert.AreEqual(2, wordCounts[7].Count);

			Assert.AreEqual("the", wordCounts[8].Word);
			Assert.AreEqual(5, wordCounts[8].Count);

			Assert.AreEqual(23, totalWordCount);
		}
	}
}
