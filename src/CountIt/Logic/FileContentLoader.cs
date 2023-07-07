using CountIt.Interfaces;
using System.IO.Abstractions;

namespace CountIt.Logic
{
	internal class FileContentLoader : IContentLoader
	{
		private readonly IFileSystem _fileSystem;

		public FileContentLoader(IFileSystem fileSystem)
		{
			_fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
		}

		public async Task<string> LoadContent(string path, string filename)
		{
			try
			{
				var combinedPath = Path.Combine(path, filename);

				string fileContent = await _fileSystem.File.ReadAllTextAsync(combinedPath);
				return fileContent;
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine($"The file cannot be found: {e.Message}");
				return string.Empty;
			}
			catch (DirectoryNotFoundException e)
			{
				Console.WriteLine($"The directory of the file cannot be found: {e.Message}");
				return string.Empty;
			}
			catch (IOException e)
			{
				Console.WriteLine($"An error occurred while reading the file: {e.Message}");
				return string.Empty;
			}
		}
	}
}
