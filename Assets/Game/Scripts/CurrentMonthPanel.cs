using UnityEngine;
using UnityEngine.UI;

namespace Birdays {
	public class CurrentMonthPanel : MonoBehaviour {
		[System.Serializable]
		public class SocialItem {
			public GameObject Root;
			public GameObject Left;
			public GameObject Right;
			public Button Button;
		}

		[SerializeField] private Button _button;
		[SerializeField] private Text _nameText;
		[SerializeField] private Text _dateText;

		[Space]

		[SerializeField] private GameObject _socials;
		[SerializeField] private SocialItem _emailSocial;
		[SerializeField] private SocialItem _smsSocial;
		[SerializeField] private SocialItem _phoneSocial;

		public Button Button => _button;
		public SocialItem EmailSocial => _emailSocial;
		public SocialItem SMSSocial => _smsSocial;
		public SocialItem PhoneSocial => _phoneSocial;

		public void Refresh(string name, int age, int year, int month, int day, int daysRemains, bool email, bool sms, bool phone) {
			_nameText.text = name;
			_dateText.text = $"{day} {Utility.GetMonth(month, true)} {year} / {Utility.GetNumericText(age, "year")} / {Utility.GetNumericText(daysRemains, "day")} remains";

			bool hasSocials = email || sms || phone;
			_socials.SetActive(hasSocials);

			if (hasSocials) {
				_emailSocial.Root.SetActive(email);
				_emailSocial.Right.SetActive(sms || phone);

				_smsSocial.Left.SetActive(email);
				_smsSocial.Root.SetActive(sms);
				_smsSocial.Right.SetActive(phone);

				_phoneSocial.Left.SetActive(email || sms);
				_phoneSocial.Root.SetActive(phone);
			}
		}
	}
}