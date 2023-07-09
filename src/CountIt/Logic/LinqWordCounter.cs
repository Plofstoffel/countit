using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]

namespace CountIt.Logic
{
	internal class LinqWordCounter : WordCounterBase, IWordCounter
	{
		public LinqWordCounter(IPunctuationRemover punctuationRemover, IWordValidator wordValidator) : base(punctuationRemover, wordValidator)
		{			
		}

		public Tuple<WordCount[], int> CountIt(string wordsToCount)
		{
			var localLowerWords = _punctuationRemover.RemoveAllPunctuation(wordsToCount)
				.Split(" ")
				.Select(w => w.ToLower())
				.Where(w => _wordValidator.ContainsOnlyLetters(w));
			return Tuple.Create<WordCount[], int>(localLowerWords.GroupBy(w => w)
				.Select(g => new WordCount(g.Key) { Count = g.Count() })
				.OrderBy(t => t.Word)
				.ToArray(),
				localLowerWords.Count());
		}
	}
}
