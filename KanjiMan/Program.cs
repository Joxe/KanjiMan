using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace KanjiMan {
	class WordTranslation {
		public string Kanji { get; set; } = "";
		public List<string> Romaji { get; set; } = new();
		public List<string> Translations { get; set; } = new();

		public override string ToString() {
			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine(Kanji);
			stringBuilder.AppendLine("Romaji:");
			Romaji.ForEach(romaji => stringBuilder.AppendLine(romaji));
			stringBuilder.AppendLine("Translations:");
			Translations.ForEach(translation => stringBuilder.AppendLine(translation));

			return stringBuilder.ToString();
		}
	}

	class Program {
		static WordTranslation? AddWord() {
			var newWord = new WordTranslation();

			{
				Console.WriteLine("Input Kanji");
				var readKanji = Console.ReadLine();

				if (readKanji != null) {
					newWord.Kanji = readKanji;
				}
			}

			{
				Console.WriteLine("Input Romaji, multiple writings separated by comma.");
				var readRomaji = Console.ReadLine();

				if (readRomaji != null) {
					var romajis = readRomaji.Split(',');
					newWord.Romaji = romajis.ToList();
				}
			}

			{
				Console.WriteLine("Input Translations, multiple writings separated by comma.");
				var readTranslations = Console.ReadLine();

				if (readTranslations != null) {
					var translations = readTranslations.Split(',');
					newWord.Translations = translations.ToList();
				}
			}

			Console.WriteLine("Add the following word? [y/n]");
			Console.WriteLine(newWord.ToString());

			while (true) {
				var response = Console.ReadLine();

				if (response!= null) {
					if (response == "y" || response == "yes") {
						return newWord;
					} else if (response == "n" || response == "no") {
						return null;
					} else {
						Console.WriteLine("(y)es or (n)o?");
					}
				}
			}
		}

		static void AddWords(List<WordTranslation> translations) {
			do {
				var newWord = AddWord();

				if (newWord != null) {
					translations.Add(newWord);
				}

				Console.WriteLine("Add more? (y)es or (n)o");
				var response = Console.ReadLine();

				if (response != null) {
					if (response == "y" || response == "yes") {
						// Do nothing, loop will take us back
					} else if (response == "n" || response == "no") {
						break;
					} else {
						Console.WriteLine("(y)es or (n)o?");
					}
				} else {
					break;
				}
			} while (true);
		}

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

		static List<WordTranslation>? ReadTranslations(string filePath) {
			if (File.Exists(filePath)) {
				using (var streamReader = new StreamReader(filePath, Encoding.Unicode)) {
					var jsonFile = streamReader.ReadToEnd();

					return JsonConvert.DeserializeObject<List<WordTranslation>>(jsonFile);
				}
			} else {
				Console.WriteLine($"Could not find translation file at \"{filePath}\"!");
				return null;
			}
		}

		static void SaveTranslations(List<WordTranslation> translations, string filePath) {
			if (File.Exists(filePath)) {
				File.Move(filePath, $"{filePath}-{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}");
			}

			var jsonFile = JsonConvert.SerializeObject(translations);
			File.WriteAllText(filePath, jsonFile.ToString(), Encoding.Unicode);
		}

		public static void Main(string[] args) {
			Console.OutputEncoding = Encoding.UTF8;
			Console.InputEncoding = Encoding.UTF8;

			Console.WriteLine("こんにちわ！");

			var filePath = "wordbase.json";

			if (args.Length > 0) {
				if (args[0].EndsWith("json") && File.Exists(args[0])) {
					filePath = args[0];
				}
			}

			var translations = ReadTranslations(filePath);

			if (translations == null) {
				Console.WriteLine("No translations found, you can either add some through this program or from the JSON file itself. Continuing with empty translation list.");
				translations= new List<WordTranslation>();
			}

			while (true) {
				Console.WriteLine("Select command:");
				Console.WriteLine("add: Adds translations to the database.");
				Console.WriteLine("translate: Starts the translation challenge.");
				Console.WriteLine("exit: Exits the program");

				var command = Console.ReadLine();

				if (command != null) {
					if (command == "add") {
						AddWords(translations);
						SaveTranslations(translations, filePath);
					} else if (command == "translate") {
						Translate(translations);
					} else if (command == "exit") {
						break;
					}
				}
			}
		}
	}
}
