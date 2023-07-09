using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Logic
{
	public abstract class WordCounterBase
	{
		protected readonly IPunctuationRemover _punctuationRemover;
		protected readonly IWordValidator _wordValidator;

		protected WordCounterBase(IPunctuationRemover punctuationRemover, IWordValidator wordValidator)
		{
			_punctuationRemover = punctuationRemover ?? throw new ArgumentNullException(nameof(punctuationRemover));
			_wordValidator = wordValidator ?? throw new ArgumentNullException(nameof(wordValidator));
		}
	}
}
