namespace gciskander_Test.Models;

public class TextRating()
{
    public void Add(string work, int rate)
	{
		Words.Add(work, rate);
	}
	private Dictionary<string, int> Words { get; set; } = new();
}
