using Auto_extension.Models;

namespace Auto_extension;

public class Continuer
{
    public Continuer(string [] words)
    {
		_words = words.ToList();

	}
	private List<string> _words { get; set; } = new();

	public WordContinue Continue(string word)
	{
        WordContinue wc = new()
        {
            Value = word,
        };

		wc.Continues = _words.FindAll(w => w.StartsWith(word)).ToArray();

        return wc;
	}
}
