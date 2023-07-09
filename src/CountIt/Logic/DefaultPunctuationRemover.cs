using CountIt.Interfaces;
using System.Text;

namespace CountIt.Logic
{
	internal class DefaultPunctuationRemover : IPunctuationRemover
	{
		public string RemoveAllPunctuation(string contentToClean)
		{
			StringBuilder sb = new();

			foreach (char c in contentToClean)
			{
				if (!char.IsPunctuation(c))
				{
					sb.Append(c);
				}
			}

			return sb.ToString();
		}
	}
}
