using Auto_extension.Interfaces;
using Auto_extension.Models;

namespace Auto_extension;

public class Continuer : IContinuer
{
	private readonly List<WordRating> _wordsDB;
	private const int CONTINUE_COUNT = 10;

	public Continuer(List<WordRating> words)
	{
		_wordsDB = Sort(words);
	}

	private static List<WordRating> Sort(List<WordRating> words)
	{
		return words
			.OrderBy(p => p.Value)
			.ThenBy(p => p.Recent)
			.ToList();
	}

	public List<WordContinue> ContinueRange(List<string> word) => word.AsParallel().Select(Continue).ToList();

	public WordContinue Continue(string word) => new(word, GetMatchingWords(word));

	private List<WordRating> GetMatchingWords(string word)
	{
		List<WordRating> words = FindWordsWithPrefix(word);

		return words
			.OrderByDescending(a => a.Recent)
			.ThenBy(a => a.Value)
			.Take(CONTINUE_COUNT)
			.ToList();
	}

	private List<WordRating> FindWordsWithPrefix(string prefix)
	{
		int start = FindStartIndex(_wordsDB, prefix);
		int end = FindEndIndex(_wordsDB, prefix);

		if (start == -1 || end == -1)
		{
			return [];
		}

		return _wordsDB.GetRange(start, end - start + 1);
	}

	private static int FindStartIndex(List<WordRating> words, string prefix)
	{
		int left = 0;
		int right = words.Count - 1;
		int result = -1;

		while (left <= right)
		{
			int mid = left + (right - left) / 2;

			if (words[mid].Value.StartsWith(prefix))
			{
				right = mid - 1;
				result = mid;
			}
			else if (string.Compare(words[mid].Value, prefix) < 0)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}

		return result;
	}

	private static int FindEndIndex(List<WordRating> words, string prefix)
	{
		int left = 0;
		int right = words.Count - 1;
		int result = -1;

		while (left <= right)
		{
			int mid = left + (right - left) / 2;

			if (words[mid].Value.StartsWith(prefix))
			{
				left = mid + 1;
				result = mid;
			}
			else if (string.Compare(words[mid].Value, prefix) <= 0)
			{
				left = mid + 1;
			}
			else
			{
				right = mid - 1;
			}
		}

		return result;
	}
}
