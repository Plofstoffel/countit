using CountIt.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Logic
{
	internal class RegexWordValidator : IWordValidator
	{
		public bool ContainsOnlyLetters(string word)
		{
			return Regex.IsMatch(word, @"^[a-zA-Z]+$", new RegexOptions(), new TimeSpan(15));
		}
	}
}
