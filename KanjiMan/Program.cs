using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace KanjiMan {
	class Program {
		public static List<WordTranslation> Translations { get; private set; } = new();

		public static void Main(string[] args) {
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

			Application.Run(new MainWindow(Translations));
		}
	}
}
