using CountIt.Interfaces;
using CountIt.Logic;

namespace CountIt.UnitTests
{
	[TestClass]
	public class WordValidatorTests
	{
		[DataTestMethod]
		[DataRow("RandomWord", true)]
		[DataRow("RandomWord!", false)]
		[DataRow("RandomWord122", false)]
		[DataRow("RandomWord ", false)]
		[DataRow(" ", false)]
		[DataRow("", false)]
		public void WhenUsingDefaultValidator_TheWordIsValid(string word, bool isValid)
		{
			//Arrange
			IWordValidator wordValidator = new DefaultWordValidator();

			//Act
			bool result = wordValidator.ContainsOnlyLetters(word);

			//Assert
			Assert.AreEqual(isValid, result);
		}

		[DataTestMethod]
		[DataRow("RandomWord", true)]
		[DataRow("RandomWord!", false)]
		[DataRow("RandomWord122", false)]
		[DataRow("RandomWord ", false)]
		[DataRow(" ", false)]
		[DataRow("", false)]
		public void WhenUsingLinqValidator_TheWordIsValid(string word, bool isValid)
		{
			//Arrange
			IWordValidator wordValidator = new LinqWordValidator();

			//Act
			bool result = wordValidator.ContainsOnlyLetters(word);

			//Assert
			Assert.AreEqual(isValid, result);
		}

		[DataTestMethod]
		[DataRow("RandomWord", true)]
		[DataRow("RandomWord!", false)]
		[DataRow("RandomWord122", false)]
		[DataRow("RandomWord ", false)]
		[DataRow(" ", false)]
		public void WhenUsingRegexValidator_TheWordIsValid(string word, bool isValid)
		{
			//Arrange
			IWordValidator wordValidator = new RegexWordValidator();

			//Act
			bool result = wordValidator.ContainsOnlyLetters(word);

			//Assert
			Assert.AreEqual(isValid, result);
		}
	}
}
