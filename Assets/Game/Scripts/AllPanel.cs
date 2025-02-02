using UnityEngine;
using UnityEngine.UI;

namespace Birdays {
	public class AllPanel : MonoBehaviour {

		[SerializeField] private Button _button;
		[SerializeField] private Image _yearsTextBackground;
		[SerializeField] private Text _ageText;
		[SerializeField] private Text _nameAndAgeText;

		public Button Button => _button;

		public void Refresh(string name, int age, int year, int month, int day) {
			_yearsTextBackground.color = Utility.GetYearsBackgroundColor(age >= 0);
			_ageText.text = age >= 0 ? age.ToString() : "";
			_nameAndAgeText.text = $"{name}\n{day} {Utility.GetMonth(month, false)} {year}";
		}
	}
}