using UnityEngine;
using UnityEngine.Events;

namespace Essentials {
	public class DelayedEvent : MonoBehaviour {

		[SerializeField, Min(0.1f)] private float _delay = 1f;
		[SerializeField] private bool _loop;

		[Space]

		[SerializeField] private UnityEvent _onAlarm;

		private float _timer;

		private void OnEnable() {
			_timer = _delay;
		}

		private void Update() {
			if (_timer > 0) {
				_timer -= Time.deltaTime;
				if (_timer <= 0) {
					_onAlarm.Invoke();
					if (_loop) {
						_timer = _delay;
					} else 
						enabled = false;
				}
			}
		}
	}
}