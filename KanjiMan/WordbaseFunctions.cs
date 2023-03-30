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
					var allTranslations = JsonConvert.DeserializeObject<List<WordTranslation>>(jsonFile);

					if (allTranslations == null) {
						return null;
					}

					var translations = new List<WordTranslation>();

					foreach (var translation in allTranslations) {
						if (translations.Find(element => element.Kanji == translation.Kanji) == null) {
							translations.Add(translation);
						} else {
							throw new InvalidDataException($"Translation for {translation.Kanji} ({translation.Romaji[0]}) already exists!");
						}
					}

					return translations;
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
	}
}
