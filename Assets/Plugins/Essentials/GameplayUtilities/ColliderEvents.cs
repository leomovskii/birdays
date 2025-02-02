using UnityEngine;
using UnityEngine.Events;

namespace Essentials {

	public enum ColliderEventType {
		TriggerEnter, TriggerExit,
		CollisionEnter, CollisionExit
	}

	public class ColliderEvents : MonoBehaviour {

		[SerializeField] private bool _interactable = true;
		[SerializeField] private ColliderEventType _eventType;
		[SerializeField] private string _targetTag;
		[SerializeField] private bool _loop = true;
		[SerializeField] private UnityEvent<Transform> _onEvent;

		public bool Interactable { get => _interactable; set => _interactable = value; }
		public bool Loop { get => _loop; set => _loop = value; }

		public UnityEvent<Transform> OnEvent => _onEvent;

		private void OnTriggerEnter(Collider other) {
			TryCallEvent(ColliderEventType.TriggerEnter, other.transform);
		}

		private void OnTriggerExit(Collider other) {
			TryCallEvent(ColliderEventType.TriggerExit, other.transform);
		}

		private void OnCollisionEnter(Collision collision) {
			TryCallEvent(ColliderEventType.CollisionEnter, collision.transform);
		}

		private void OnCollisionExit(Collision collision) {
			TryCallEvent(ColliderEventType.CollisionExit, collision.transform);
		}

		private void TryCallEvent(ColliderEventType triggeredEvent, Transform interactor) {
			if (!_interactable || triggeredEvent != _eventType)
				return;

			if (string.IsNullOrEmpty(_targetTag) || interactor.CompareTag(_targetTag)) {
				_onEvent?.Invoke(interactor);
				_interactable = _loop;
			}
		}
	}
}