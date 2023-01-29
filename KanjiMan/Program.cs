using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace KanjiMan {
	class Program {
		static void Translate(List<WordTranslation> translations) {
			if (translations.Count == 0) {
				Console.WriteLine("Translations were empty!");
				return;
			}

			var attempts = 0;
			var correctGuesses = 0;

			var printSuccessRate = () => {
				if (correctGuesses == 0) {
					Console.WriteLine($"\nYou currently have a 0% success rate!");
				} else {
					Console.WriteLine($"\nYou currently have a {Math.Round(((float)correctGuesses / (float)attempts) * 100.0f)}% success rate!");
				}
			};

			while (true) {
				++attempts;
				var randomTranslation = translations[new Random().Next(0, translations.Count - 1)];

				Console.WriteLine("===============================");
				Console.WriteLine($"Input romaji for {randomTranslation.Kanji}. Input 123 to stop");
				var input = Console.ReadLine();

				if (input != null) {
					if (input == "123") {
						return;
					} else if (randomTranslation.Romaji.Contains(input)) {
						++correctGuesses;

						Console.WriteLine("\nCorrect! Translation(s):");
						randomTranslation.Translations.ForEach(x => Console.WriteLine($"\t{x}"));

						printSuccessRate();
					} else {
						Console.WriteLine("\nIncorrect! Correct answers were:");
						randomTranslation.Romaji.ForEach(x => Console.WriteLine($"\t{x}"));
						Console.WriteLine("\nTranslation(s):");
						randomTranslation.Translations.ForEach(x => Console.WriteLine($"\t{x}"));

						printSuccessRate();
					}
				}
			}
		}

		public static List<WordTranslation> Translations { get; private set; } = new();

		public static void Main(string[] args) {
			//Console.OutputEncoding = Encoding.UTF8;
			//Console.InputEncoding = Encoding.UTF8;

			//Console.WriteLine("こんにちわ！");

			var filePath = "wordbase.json";

			if (args.Length > 0) {
				if (args[0].EndsWith("json") && File.Exists(args[0])) {
					filePath = args[0];
				}
			}

			var translations = WordbaseFunctions.ReadTranslations(filePath);

			if (translations == null || translations.Count == 0) {
				Console.WriteLine("No translations found, you can either add some through this program or from the JSON file itself. Continuing with empty translation list.");
				Translations = new List<WordTranslation>();
			} else {
				Translations = translations;
			}

			Application.Run(new MainWindow());

			//while (true) {
			//	Console.WriteLine("Select command:");
			//	Console.WriteLine("add: Adds translations to the database.");
			//	Console.WriteLine("translate: Starts the translation challenge.");
			//	Console.WriteLine("exit: Exits the program");
			//
			//	var command = Console.ReadLine();
			//
			//	if (command != null) {
			//		if (command == "add") {
			//			AddWords(translations);
			//			SaveTranslations(translations, filePath);
			//		} else if (command == "translate") {
			//			Translate(translations);
			//		} else if (command == "exit") {
			//			break;
			//		}
			//	}
			//}
		}
	}
}
