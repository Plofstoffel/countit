using CountIt.Interfaces;
using CountIt.Logic;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace CountIt
{
	internal static class Program
	{
		private const string _fileName = "Default.txt";
		static async Task Main()
		{
			// Create a new service collection
			var services = new ServiceCollection();

			// Register your services
			services.AddSingleton<IWordValidator, DefaultWordValidator>();
			services.AddSingleton<IWordCounter, DefaultWordCounter>();
			services.AddSingleton<IFileSystem, FileSystem>();
			services.AddSingleton<IContentLoader, FileContentLoader>();

			// Build the service provider
			var serviceProvider = services.BuildServiceProvider();

			// Resolve the service you want to use
			var contentLoader = serviceProvider.GetRequiredService<IContentLoader>();
			var wordCounter = serviceProvider.GetRequiredService<IWordCounter>();

			// Use the service
			string content = await contentLoader.LoadContent(Environment.CurrentDirectory, _fileName);
			var countedWordsResult = wordCounter.CountIt(content);

			//Print results to screen
			Console.WriteLine($"Number of words: {countedWordsResult.Item2}");
			foreach (var word in countedWordsResult.Item1)
			{
				Console.WriteLine($"{word.Word} {word.Count}");
			}

			Console.ReadLine();
		}
	}
}