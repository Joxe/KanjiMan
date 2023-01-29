﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanjiMan {
	public partial class MainWindow : Form {
		public int Attempts { get; set; } = 0;
		public int Correct { get; set; } = 0;

		private WordTranslation? m_currentTranslation = null;

		public MainWindow() {
			InitializeComponent();
			ResultLabel.Text = "";
			PresentChallenge();
		}

		void UpdateResultLabels() {
			AttemptsLabel.Text = Attempts.ToString();
			CorrectLabel.Text = Correct.ToString();

			if (Attempts > 0) {
				PercentLabel.Text = $"{Math.Round(((float)Correct / (float)Attempts) * 100.0f)}%";
			} else {
				PercentLabel.Text = "0%";
			}
		}

		void PresentChallenge() {
			if (Program.Translations != null && Program.Translations.Count > 0) {
				var randomTranslation = Program.Translations[new Random().Next(0, Program.Translations.Count - 1)];

				InputTextBox.Text = "";
				KanjiLabel.Text = randomTranslation.Kanji;

				m_currentTranslation = randomTranslation;
			}
		}

		void SubmitAnswer() {
			if (m_currentTranslation != null) {
				++Attempts;

				if (m_currentTranslation.Romaji.Contains(InputTextBox.Text)) {
					ResultLabel.Text = $"Correct! {m_currentTranslation.Kanji} can be read as '{InputTextBox.Text}'";
					++Correct;
				} else {
					ResultLabel.Text = $"Incorrect! See the available answers for {m_currentTranslation.Kanji} below!";
				}

				RomajiBox.Items.Clear();
				TranslationBox.Items.Clear();
				RomajiBox.Items.AddRange(m_currentTranslation.Romaji.ToArray());
				TranslationBox.Items.AddRange(m_currentTranslation.Translations.ToArray());

				UpdateResultLabels();
			}

			PresentChallenge();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				SubmitAnswer();
			}
		}

		private void SubmitButton_Click(object sender, EventArgs e) {
			SubmitAnswer();
		}

		private void button2_Click(object sender, EventArgs e) {
			if (m_currentTranslation != null) {
				ResultLabel.Text = $"See the available answers for {m_currentTranslation.Kanji} below!";

				RomajiBox.Items.Clear();
				TranslationBox.Items.Clear();
				RomajiBox.Items.AddRange(m_currentTranslation.Romaji.ToArray());
				TranslationBox.Items.AddRange(m_currentTranslation.Translations.ToArray());
			}

			PresentChallenge();
		}
	}
}