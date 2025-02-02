using Essentials;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MoneyGiant.UI {
	[ExecuteInEditMode]
	public class HorizontalLayout : MonoBehaviour {

		private enum Type {
			Left, Center, Right
		}

		[SerializeField] private Type _type;
		[SerializeField] private bool _auto;
		[SerializeField] private bool _followParentRebuil;
		[SerializeField] private float _space = 10f;
		[SerializeField, ShowIf(nameof(ShowIndent))] private float _indent;

		[Space]

		[SerializeField] private bool _reverseArrangement;
		[SerializeField] private RectTransform[] _childs;

		private bool ShowIndent => _type != Type.Center;

		private RectTransform _rect;

		private RectTransform Rect => _rect != null ? _rect : _rect = GetComponent<RectTransform>();

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

			if (_reverseArrangement)
				System.Array.Reverse(activeChildren);

			float totalWidth = activeChildren.Sum(c => c.rect.width) + _space * (activeChildren.Length - 1);
			float pX = 0.5f * (int) _type, x = _type switch {
				Type.Left => _indent,
				Type.Center => -totalWidth / 2f,
				Type.Right => -totalWidth - _indent,
				_ => 0f
			};

			foreach (var child in activeChildren) {
				child.anchorMin = new Vector2(pX, child.anchorMin.y);
				child.anchorMax = new Vector2(pX, child.anchorMax.y);
				child.pivot = new Vector2(0f, child.pivot.y);
				child.anchoredPosition = new Vector2(x, child.anchoredPosition.y);
				x += child.rect.width + _space;
			}

			if (_followParentRebuil && Rect.parent != null)
				LayoutRebuilder.MarkLayoutForRebuild((RectTransform) Rect.parent);
		}

	}
}