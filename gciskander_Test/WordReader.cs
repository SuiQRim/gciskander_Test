using Auto_extension.Models;
using System.Text;

namespace gciskander_Test;

internal class WordReader
{
	private readonly List<string> _lines;

	public WordReader()
    {
		_lines = ReadLines();
	}

	private static List<string> ReadLines()
	{
		StringBuilder stringBuilder = new();

		while (true)
		{
			string? input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				break;
			}
			stringBuilder.AppendLine(input);
		}

		return stringBuilder.ToString().Split(Environment.NewLine).SkipLast(1).ToList();
	}

	public List<WordRating> GetWordRatings(int start)
	{
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
		int wordsCount = Convert.ToInt32(_lines[start]);
		int wordListStart = start + 1;
		List<string> words = new();

		for (int i = wordListStart; i < wordsCount + wordListStart; i++)
		{
			words.Add(_lines[i]);
		}

		return words;
	}

}
