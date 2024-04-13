using Auto_extension;
using Auto_extension.Models;
using gciskander_Test;

const int startLine = 0;

WordReader wordReader = new ();

List<WordRating> wordRatings = wordReader.GetWordRatings(startLine);
List<string> wordPieces = wordReader.GetWordPieces(startLine + wordRatings.Count + 1);

Continuer continuer = new(wordRatings);
List<WordContinue> wordContinues = continuer.ContinueRange(wordPieces);


foreach (WordContinue item in wordContinues)
{
	Console.WriteLine(item.Value);
	foreach (string word in item.Continues)
	{
		Console.WriteLine("".PadLeft(4) + word);
	}
}