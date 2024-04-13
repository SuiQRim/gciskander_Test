using Auto_extension.Interfaces;
using Auto_extension.Models;

namespace Auto_extension;

public class Continuer : IContinuer
{
	private readonly List<WordRating> _wordsDB;

	public Continuer(List<WordRating> words)
	{
		//Сортируя базу здесь и обращаясь в будущем мы всегда получим значения в порядке частоты
		_wordsDB = words.OrderByDescending(p => p.Recent).ThenBy(p => p.Value).ToList();
	}

	public WordContinue Continue(string word)
	{
		List<string> matchingWords = GetMatchingWords(word);

		WordContinue wc = new (word, matchingWords.ToList());

		return wc;
	}

	private List<string> GetMatchingWords(string word)
	{
		List<string> wordsStartingWithInput = _wordsDB
			.Select(e => e.Value)
			.Where(w => w.StartsWith(word))
			.OrderBy(w => w)
			.ToList();

		return wordsStartingWithInput;
	}

	public List<WordContinue> ContinueRange(List<string> word)
	{
		return word.Select(Continue).ToList();
	}
}
