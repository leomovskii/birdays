using System;
using UnityEngine;
using UnityEngine.UI;

namespace Birdays {
	public class FamousPanel : MonoBehaviour {

		[SerializeField] private Button _button;
		[SerializeField] private Text _nameText;
		[SerializeField] private Text _dateText;

		public Button Button => _button;

		public void Refresh(string name, DateTime date) {
			_nameText.text = name;
			_dateText.text = $"{date.Day} {Utility.GetMonth(date.Month, true)} {date.Year}";
		}
	}
}