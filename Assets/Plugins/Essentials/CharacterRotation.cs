using UnityEngine;
using UnityEngine.EventSystems;

namespace Essentials {
	public class CharacterRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

		[SerializeField] private Transform _character;
		[SerializeField] private float _rotationSpeed = 20f;
		[SerializeField] private float _autoRotationSpeed = 180f;

		private Quaternion _initialRotation;
		private float _touchPositionX;
		private bool _rotating;

		private void Start() {
			_initialRotation = _character.localRotation;
		}

		public void OnPointerDown(PointerEventData eventData) {
			_rotating = true;
			_touchPositionX = eventData.position.x;
		}

		public void OnPointerUp(PointerEventData _) {
			_rotating = false;
		}

		public void OnDrag(PointerEventData eventData) {
			var rotationIntent = (_touchPositionX - eventData.position.x) * _rotationSpeed * Time.deltaTime;
			_character.Rotate(0f, rotationIntent, 0f);
			_touchPositionX = eventData.position.x;
		}

		private void Update() {
			if (!_rotating && Quaternion.Angle(_character.localRotation, _initialRotation) > 0.1f)
				_character.localRotation = Quaternion.RotateTowards(_character.localRotation, _initialRotation, _autoRotationSpeed * Time.deltaTime);
		}
	}
}