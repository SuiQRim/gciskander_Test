using Auto_extension.Models;
using System.Text;

namespace gciskander_Test;

internal class WordDataManager
{
	private List<string>? _lines;

	public async Task ReadFile(string path)
	{
		using FileStream fs = new(path, FileMode.Open);
		using StreamReader streamReader = new (fs);

		string text = await streamReader.ReadToEndAsync();

		_lines = text.Split(Environment.NewLine).ToList();
	}

	public List<WordRating> GetWordRatings(int start)
	{
		if (_lines == null)
			return [];

		int wordsCount = Convert.ToInt32(_lines[start]);
		int wordListStart = start + 1;
		List<WordRating> rating = new();

		for (int i = wordListStart; i < wordsCount + wordListStart; i++)
		{
			string[] rate = _lines[i].Split(" ");

			rating.Add(new(rate[0], Convert.ToInt32(rate[1])));
		}

		return rating;
	}

	public List<string> GetWordPieces(int start)
	{
		if (_lines == null)
			return [];

		int wordsCount = Convert.ToInt32(_lines[start]);
		int wordListStart = start + 1;
		List<string> words = new();

		for (int i = wordListStart; i < wordsCount + wordListStart; i++)
		{
			words.Add(_lines[i]);
		}

		return words;
	}

	public async Task WriteToFile(string path, List<WordContinue> wordContinues)
	{
		using FileStream fileStream = new(path, FileMode.Create);
		StreamWriter sw = new(fileStream);
		await sw.WriteLineAsync(WordsToResult(wordContinues));
	}

	private static string WordsToResult(List<WordContinue> wordContinues)
	{
		StringBuilder sb = new();
		foreach (WordContinue item in wordContinues)
		{
			sb.AppendLine($"{item.Value}");
			foreach (WordRating word in item.Continues)
			{
				sb.AppendLine($"{"".PadLeft(4)}{word.Value}");
			}
			sb.AppendLine();
		}

		return sb.ToString();
	}
}
