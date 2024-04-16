using Auto_extension;
using Auto_extension.Models;
using gciskander_Test;

WordDataManager wdManager = new ();
await wdManager.ReadFile(@"TestFilePath");

const int startLine = 0;
List<WordRating> wordRatings = wdManager.GetWordRatings(startLine);
List<string> wordPieces = wdManager.GetWordPieces(startLine + wordRatings.Count + 1);

Continuer continuer = new(wordRatings);
List<WordContinue> wordContinues = continuer.ContinueRange(wordPieces);

// Если надо можно вывести в консоль (но туда не лезет большой объем данных)
//wdManager.WriteToConsole(wordContinues);
await wdManager.WriteToFile(@"ResultPath", wordContinues);