using Auto_extension.Models;

namespace Auto_extension.Interfaces;

public interface IContinuer
{
	WordContinue Continue(string word);

	List<WordContinue> ContinueRange(List<string> word);
}
