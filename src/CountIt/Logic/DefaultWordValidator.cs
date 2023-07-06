using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Logic
{
	internal class DefaultWordValidator : IWordValidator
	{
		public bool ContainsOnlyLetters(string word)
		{
			if (string.IsNullOrEmpty(word)) return false;

			foreach (char c in word)
			{
				if (!char.IsLetter(c))
				{
					return false;
				}
			}

			return true;
		}
	}
}
