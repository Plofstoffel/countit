using System.Runtime.CompilerServices;

namespace CountIt.Models
{
	public class WordCount
	{
		public string Word { get; set; }
		public int Count { get; set; }

		public WordCount(string word)
		{
			if (string.IsNullOrEmpty(word))
			{
				throw new ArgumentNullException(nameof(word));
			}

			Word = word.ToLower();
		}
	}
}
