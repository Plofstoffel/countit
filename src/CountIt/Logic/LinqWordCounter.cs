using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]

namespace CountIt.Logic
{
	internal class LinqWordCounter : WordCounterBase, IWordCounter
	{
		private readonly IWordValidator _wordValidator;

		public LinqWordCounter(IWordValidator wordValidator) : base(wordValidator)
		{
			_wordValidator = wordValidator ?? throw new ArgumentNullException(nameof(wordValidator));
		}

		public Tuple<WordCount[], int> CountIt(string wordsToCount)
		{
			var localLowerWords = new string(wordsToCount.Where(c => char.IsLetter(c) || c == ' ').ToArray())
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
