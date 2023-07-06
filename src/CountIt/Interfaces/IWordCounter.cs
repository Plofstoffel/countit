using CountIt.Logic;

namespace CountIt.Interfaces
{
	public interface IWordCounter
	{
		Tuple<WordCount[], int> CountIt(string wordsToCount);
	}
}
