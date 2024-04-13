using Auto_extension;
using Auto_extension.Interfaces;
using Auto_extension.Models;
using System.Text;

string text = Input();

List<string> inputs = text.Split(Environment.NewLine).SkipLast(1).ToList();


const int wordBaseStart = 1;
int recentWordsCount = Convert.ToInt32(inputs[0]);
List<WordRating> wordsBase = ParseWordsBase(inputs, wordBaseStart, recentWordsCount);

Continuer continuer = new(wordsBase);

int wordsCount = Convert.ToInt32(inputs[wordsBase.Count + 1]);
int wordsStart = wordsBase.Count + 2;
List<string> words = ParseWords(inputs, wordsStart, wordsCount);

PrintWords(continuer, words);


static List<WordRating> ParseWordsBase(List<string> inputs, int start, int wordCount)
{
	List<WordRating> rating = new();
	for (int i = start; i < wordCount + start; i++)
	{
		string[] rate = inputs[i].Split(" ");

		rating.Add(new(rate[0], Convert.ToInt32(rate[1])));
	}

	return rating;
}

static List<string> ParseWords(List<string> inputs, int start, int wordCount)
{
	List<string> words = new();
	for (int i = start; i < wordCount + start; i++)
	{
		words.Add(inputs[i]);
	}

	return words;
}


static string Input()
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

	return stringBuilder.ToString();
}

static void PrintWords(IContinuer continuer, List<string> words)
{
	foreach (var item in words)
	{
		WordContinue continues = continuer.Continue(item);
		Console.WriteLine(continues.Value);
		foreach (var word in continues.Continues)
		{
			Console.WriteLine("".PadLeft(4) + word);
		}
	}
}