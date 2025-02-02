using UnityEngine;

namespace Essentials {
	public class Billboard : MonoBehaviour {

		[SerializeField] private bool _blockX;
		[SerializeField] private bool _blockY;
		[SerializeField] private bool _blockZ;

		private Vector3 _direction;

		private void LateUpdate() {
			if (Camera.main == null)
				return;

			_direction = Camera.main.transform.position - transform.position;

			if (_blockX)
				_direction.x = 0;
			if (_blockY)
				_direction.y = 0;
			if (_blockZ)
				_direction.z = 0;

			if (_blockX && _blockY && _blockZ)
				return;

			if (_direction != Vector3.zero) {
				transform.rotation = Quaternion.LookRotation(_direction);
			}
		}
	}
}