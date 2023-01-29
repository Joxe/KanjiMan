using Newtonsoft.Json;
using System.Text;

namespace KanjiMan {
	internal class WordTranslation {
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

	internal class WordbaseFunctions {
		internal static List<WordTranslation>? ReadTranslations(string filePath) {
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

		internal static void SaveTranslations(List<WordTranslation> translations, string filePath) {
			if (File.Exists(filePath)) {
				File.Move(filePath, $"{filePath}-{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString()}");
			}

			var jsonFile = JsonConvert.SerializeObject(translations);
			File.WriteAllText(filePath, jsonFile.ToString(), Encoding.Unicode);
		}

		internal static WordTranslation? AddWord() {
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

		internal static void AddWords(List<WordTranslation> translations) {
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
	}
}
