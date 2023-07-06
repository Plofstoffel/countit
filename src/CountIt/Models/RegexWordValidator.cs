using CountIt.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Models
{
	internal class RegexWordValidator: IWordValidator
	{
		public bool ContainsOnlyLetters(string word)
		{
			return Regex.IsMatch(word, @"^[a-zA-Z]+$");
		}		
	}
}
