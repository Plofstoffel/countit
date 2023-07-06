using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]

namespace CountIt.Models
{
	internal class LinqWordValidator : IWordValidator
	{
		public bool ContainsOnlyLetters(string word)
		{
			return !word.Where(c => !char.IsLetter(c)).Any();
		}
	}
}
