﻿using CountIt.Interfaces;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CountIt.UnitTests")]
namespace CountIt.Models
{
	internal class DefaultWordCounter : WordCounterBase, IWordCounter
	{
		private readonly IWordValidator _wordValidator;

		public DefaultWordCounter(IWordValidator wordValidator) : base(wordValidator)
		{
			_wordValidator = wordValidator ?? throw new ArgumentNullException(nameof(wordValidator));
		}

		public Tuple<WordCount[], int> CountIt(string input)
		{
			string cleanInput = RemoveNonAlphaChars(input);
			string[] words = cleanInput.Split(' ');
			int totalWordCount = 0;
			WordCount[] wordCounts = new WordCount[words.Length];
			int index = 0;

			foreach (string word in words)
			{
				if (_wordValidator.ContainsOnlyLetters(word) && !string.IsNullOrEmpty(word))
				{
					totalWordCount++;
					int existingIndex = Array.FindIndex(wordCounts, wc => wc != null && string.Equals(wc.Word, word, StringComparison.OrdinalIgnoreCase));

					if (existingIndex != -1)
					{
						wordCounts[existingIndex].Count++;
					}
					else
					{
						wordCounts[index] = new WordCount(word) { Count = 1 };
						index++;
					}
				}
			}

			Array.Resize(ref wordCounts, index);

			QuickSort(wordCounts, 0, wordCounts.Length - 1);

			return Tuple.Create(wordCounts, totalWordCount);
		}

		private string RemoveNonAlphaChars(string words)
		{
			StringBuilder sb = new StringBuilder();

			foreach (char c in words)
			{
				if (char.IsLetter(c) || c == ' ')
				{
					sb.Append(c);
				}
			}

			return sb.ToString();
		}

		private void QuickSort(WordCount[] wordCounts, int low, int high)
		{
			if (low < high)
			{
				int pivotIndex = Partition(wordCounts, low, high);
				QuickSort(wordCounts, low, pivotIndex - 1);
				QuickSort(wordCounts, pivotIndex + 1, high);
			}
		}

		private int Partition(WordCount[] wordCounts, int low, int high)
		{
			WordCount pivot = wordCounts[high];
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (string.Compare(wordCounts[j].Word, pivot.Word, StringComparison.OrdinalIgnoreCase) <= 0)
				{
					i++;
					Swap(wordCounts, i, j);
				}
			}

			Swap(wordCounts, i + 1, high);
			return i + 1;
		}

		private void Swap(WordCount[] wordCounts, int i, int j)
		{
			WordCount temp = wordCounts[i];
			wordCounts[i] = wordCounts[j];
			wordCounts[j] = temp;
		}

	}
}
