using UnityEngine;
using UnityEngine.Events;

namespace Essentials {
	public class PhysicButton : MonoBehaviour {

		[SerializeField] private bool _interactable = true;

		[Space]

		[SerializeField] private UnityEvent _onClick;

		public bool Interactable {
			get => _interactable;
			set => _interactable = value;
		}

		public UnityEvent OnClick => _onClick;

		private void OnMouseDown() {
			if (_interactable)
				_onClick?.Invoke();
		}
	}
}