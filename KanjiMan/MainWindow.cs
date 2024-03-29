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
		private List<WordTranslation> m_allTranslations = new();
		private List<WordTranslation> m_remainingTranslations = new();
		private List<WordTranslation> m_recentlyFailedAttempts = new();

		internal MainWindow(List<WordTranslation> wordList) {
			InitializeComponent();
			ResultLabel.Text = "";
			m_allTranslations = wordList;
			m_remainingTranslations = wordList;
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
			if (m_remainingTranslations.Count == 0) {
				if (m_recentlyFailedAttempts.Count > 0) {
					// Move the previous failures into the remaining list so we can try them again.
					m_remainingTranslations.AddRange(m_recentlyFailedAttempts);
					m_recentlyFailedAttempts.RemoveRange(0, m_recentlyFailedAttempts.Count);
				} else if (m_allTranslations.Count == 0) {
					ResultLabel.Text = "No available translations!";
					RomajiBox.Items.Clear();
					TranslationBox.Items.Clear();
					InputTextBox.Text = "";
					KanjiLabel.Text = "";
					return;
				} else {
					m_remainingTranslations = m_allTranslations;
				}
			}

			var randomTranslation = m_remainingTranslations[new Random().Next(0, m_remainingTranslations.Count - 1)];

			InputTextBox.Text = "";
			KanjiLabel.Text = randomTranslation.Kanji;

			m_currentTranslation = randomTranslation;
		}

		void SubmitAnswer() {
			if (m_currentTranslation != null) {
				++Attempts;

				var correctAnswer = false;

				foreach (var romaji in m_currentTranslation.Romaji) {
					if (romaji.Equals(InputTextBox.Text, StringComparison.OrdinalIgnoreCase)) {
						correctAnswer = true;
						break;
					}
				}

				if (correctAnswer) {
					ResultLabel.Text = $"Correct! {m_currentTranslation.Kanji} can be read as '{InputTextBox.Text}'";
					m_remainingTranslations.Remove(m_currentTranslation);
					++Correct;
				} else {
					ResultLabel.Text = $"Incorrect! See the available answers for {m_currentTranslation.Kanji} below!";
					// Move the current translation from the remaining to failed list
					m_recentlyFailedAttempts.Add(m_currentTranslation);
					m_remainingTranslations.Remove(m_currentTranslation);
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
