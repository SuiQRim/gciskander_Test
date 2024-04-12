using Auto_extension;
using Auto_extension.Models;
using System.Text;

string text = Input();

Console.WriteLine(text);

List<string> inputs = text.Split("\n").SkipLast(1).ToList();

int recentWordsCount = Convert.ToInt32(inputs[0]);

List<TextRating> rating = new ();
int start = 1;
for (int i = start; i < recentWordsCount + start; i++)
{
	string [] rate = inputs[i].Split(" ");

	rating.Add(new()
	{
		Word = rate[0],
		Recent = Convert.ToInt32(rate[1]),
	});
}

rating = rating.OrderByDescending(r => r.Recent).ToList();

foreach (var r in rating)
{
	Console.WriteLine($"{r.Word} - {r.Recent}");
}


List<string> words = new ();
int wordsCount = Convert.ToInt32(inputs[recentWordsCount + 1]);

start = recentWordsCount + 2;
for (int i = start; i < wordsCount + start; i++)
{
	words.Add(inputs[i]);
}

string[] a = rating.Select(x => x.Word).ToArray();
Continuer continuer = new(a);


foreach (var item in words)
{
	WordContinue continues = continuer.Continue(item);
	Console.WriteLine(continues.Value);
	foreach (var word in continues.Continues)
	{
		Console.WriteLine("".PadLeft(4) + word);
	}
}

static string Input ()
{
	StringBuilder stringBuilder = new();

	while (true)
	{
		string? input = Console.ReadLine();

		if (string.IsNullOrEmpty(input))
		{
			break;
		}
		stringBuilder.Append(input + "\n");
	}

	return stringBuilder.ToString();
}