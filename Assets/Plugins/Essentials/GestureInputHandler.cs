using UnityEngine;
using UnityEngine.Events;

namespace Essentials {
	public class GestureInputHandler : Singleton<GestureInputHandler> {

		//[SerializeField] private float _moveTreshold = 0.1f;
		[SerializeField] private float _rotateTreshold = 0.1f;
		[SerializeField] private float _scaleTreshold = 0.1f;

		[SerializeField] private UnityEvent<Vector2> _onMoveEvent;
		[SerializeField] private UnityEvent<Vector2> _onRotateEvent;
		[SerializeField] private UnityEvent<float> _onScaleEvent;

		public UnityEvent<Vector2> OnMoveInput => _onMoveEvent;
		public UnityEvent<Vector2> OnRotateInput => _onRotateEvent;
		public UnityEvent<float> OnScaleInput => _onScaleEvent;

		private void Update() {
			if (Application.isEditor)
				UpdateEditor();
			else
				UpdateMobile();
		}

		private void OnApplicationFocus(bool _) {
			_mode = EditorGestureInputMode.None;
			_wasTwoTouchesLastFrame = false;
		}

		private void OnApplicationPause(bool _) {
			_mode = EditorGestureInputMode.None;
			_wasTwoTouchesLastFrame = false;
		}

		#region Editor behaviour

		private enum EditorGestureInputMode {
			None, Move, Rotate
		}

		private EditorGestureInputMode _mode;
		private Vector2 _cursorPosition;

		private void UpdateEditor() {
			if (Input.mouseScrollDelta.y != 0)
				_onScaleEvent?.Invoke(Input.mouseScrollDelta.y);

			if (_mode == EditorGestureInputMode.None) {
				if (Input.GetKeyDown(KeyCode.Mouse2)) {
					_cursorPosition = Input.mousePosition;
					_mode = EditorGestureInputMode.Move;

				} else if (Input.GetKeyDown(KeyCode.Mouse1)) {
					_cursorPosition = Input.mousePosition;
					_mode = EditorGestureInputMode.Rotate;

				}
			} else if (_mode == EditorGestureInputMode.Move) {
				if (Input.GetKeyUp(KeyCode.Mouse2))
					_mode = EditorGestureInputMode.None;

			} else {
				if (Input.GetKeyUp(KeyCode.Mouse1))
					_mode = EditorGestureInputMode.None;
			}

			if (_mode != EditorGestureInputMode.None) {
				(_mode == EditorGestureInputMode.Move ? _onMoveEvent : _onRotateEvent)?.Invoke((Vector2) Input.mousePosition - _cursorPosition);
				_cursorPosition = Input.mousePosition;
			}
		}

		#endregion
		#region Mobile behaviour

		private Vector2 _touchStart;
		private Vector2 _initialTouchDistance;
		//private Vector2 _initialTouchMiddlePoint;
		//private float _initialTouchAngle;
		private bool _wasTwoTouchesLastFrame;

		private void UpdateMobile() {
			if (Input.touchCount == 1) {
				if (_wasTwoTouchesLastFrame) {
					_touchStart = Input.GetTouch(0).position;
					_wasTwoTouchesLastFrame = false;
				}
				HandleSingleFingerSwipe(Input.GetTouch(0));

			} else if (Input.touchCount == 2) {
				HandleTwoFingerGesture(Input.GetTouch(0), Input.GetTouch(1));
				_wasTwoTouchesLastFrame = true;

			} else
				_wasTwoTouchesLastFrame = false;
		}

		private void HandleSingleFingerSwipe(Touch touch) {
			if (touch.phase == TouchPhase.Began) {
				_touchStart = touch.position;

			} else if (touch.phase == TouchPhase.Moved) {
				_onMoveEvent?.Invoke(touch.position - _touchStart);
				_touchStart = touch.position;
			}
		}

		private void HandleTwoFingerGesture(Touch touch0, Touch touch1) {
			if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began) {
				_initialTouchDistance = touch0.position - touch1.position;
				//_initialTouchMiddlePoint = (touch0.position + touch1.position) / 2;
				//_initialTouchAngle = Vector2.SignedAngle(Vector2.right, touch0.position - touch1.position);

			} else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved) {
				var currentTouchDistance = touch0.position - touch1.position;
				//var currentTouchMiddlePoint = (touch0.position + touch1.position) / 2;

				var scaleInput = (currentTouchDistance.magnitude - _initialTouchDistance.magnitude) / _initialTouchDistance.magnitude;
				if (Mathf.Abs(scaleInput) >= _scaleTreshold) {
					_onScaleEvent?.Invoke((currentTouchDistance.magnitude - _initialTouchDistance.magnitude) / _initialTouchDistance.magnitude);
					_initialTouchDistance = currentTouchDistance;
				}

				var rotateInput = (touch0.deltaPosition + touch1.deltaPosition) / 2;
				rotateInput.x = Mathf.Abs(rotateInput.x) < _rotateTreshold ? 0 : rotateInput.x;
				rotateInput.y = Mathf.Abs(rotateInput.y) < _rotateTreshold ? 0 : rotateInput.y;

				if (rotateInput != Vector2.zero)
					_onRotateEvent?.Invoke(rotateInput);
				/*
				var moveInput = currentTouchMiddlePoint - _initialTouchMiddlePoint;
				if (moveInput.magnitude >= _moveTreshold) {
					_onMoveEvent?.Invoke(currentTouchMiddlePoint - _initialTouchMiddlePoint);
					_initialTouchMiddlePoint = currentTouchMiddlePoint;
				}*/
			}
		}

		#endregion
	}
}