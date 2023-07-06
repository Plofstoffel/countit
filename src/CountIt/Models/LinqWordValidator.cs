using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]

namespace CountIt.Models
{
	internal class LinqWordValidator : IWordValidator
	{
		public bool ContainsOnlyLetters(string word)
		{
			if (string.IsNullOrEmpty(word)) return false;

			return !word.Any(c => !char.IsLetter(c));
		}
	}
}
