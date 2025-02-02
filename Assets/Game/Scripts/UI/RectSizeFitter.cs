using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MoneyGiant.UI {
	[ExecuteInEditMode]
	public class RectSizeFitter : MonoBehaviour {

		private enum Type {
			None, Horizontal, Vertical, Both
		}

		[SerializeField] private Type _type;
		[SerializeField] private bool _auto;
		[SerializeField] private bool _followParentRebuil;
		[SerializeField] private RectTransform[] _childs;

		private Vector2 _size;
		private RectTransform _rect;

		private RectTransform Rect => _rect != null ? _rect : _rect = GetComponent<RectTransform>();

		private bool AllowH => _type == Type.Horizontal || _type == Type.Both;
		private bool AllowV => _type == Type.Vertical || _type == Type.Both;

		private void Update() {
			if (_auto)
				Rebuild();
		}

		[ContextMenu("Rebuild")]
		public void Rebuild() {
			if (_childs == null || _childs.Length == 0)
				return;

			var activeChildren = _childs.Where(c => c != null && c.gameObject.activeSelf).ToArray();
			if (activeChildren.Length == 0)
				return;

			_size = Rect.sizeDelta;
			if (AllowH)
				_size.x = 0f;
			if (AllowV)
				_size.y = 0f;

			foreach (var child in activeChildren) {
				_size.x += AllowH ? child.rect.width : 0f;
				_size.y += AllowV ? child.rect.height : 0f;
			}

			_rect.sizeDelta = _size;
			if (_followParentRebuil && Rect.parent != null)
				LayoutRebuilder.MarkLayoutForRebuild((RectTransform) Rect.parent);
		}
	}
}