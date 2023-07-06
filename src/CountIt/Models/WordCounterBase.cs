using CountIt.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Models
{
	public abstract class WordCounterBase
	{
		public WordCounterBase(IWordValidator wordValidator) { }
	}
}
