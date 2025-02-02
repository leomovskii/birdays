using UnityEngine;

namespace Essentials {
	public class ShowIfAttribute : PropertyAttribute {

		public string Condition { get; private set; }
		public bool ExpectedValue { get; private set; }

		public ShowIfAttribute(string condition, bool expectedValue = true) {
			Condition = condition;
			ExpectedValue = expectedValue;
		}
	}
}