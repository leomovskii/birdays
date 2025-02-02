using System.Collections.Generic;

namespace Birdays {
	[System.Serializable]
	public class BirdayData {

		public enum SocialType {
			Phone, Email, Twitter, Telegram, Facebook, Instagram, Other
		}

		[System.Serializable]
		public class Social {
			public SocialType Type;
			public string Data;
		}

		public string Name;
		public string Date;
		public bool YearIsKnown;
		public string Description;
		public string PhoneNumber;
		public string Email;

		public List<Social> Socials;

	}
}