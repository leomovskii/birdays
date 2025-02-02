using Essentials;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MoneyGiant.UI {
	[ExecuteInEditMode]
	public class VerticalLayout : MonoBehaviour {

		private enum Type {
			Bottom, Center, Top
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

			float totalHeight = activeChildren.Sum(c => c.rect.height) + _space * (activeChildren.Length - 1);
			float pY = 0.5f * (int) _type, y = _type switch {
				Type.Bottom => _indent,
				Type.Center => -totalHeight / 2f,
				Type.Top => -totalHeight - _indent,
				_ => 0f
			};

			foreach (var child in activeChildren) {
				child.anchorMin = new Vector2(child.anchorMin.x, pY);
				child.anchorMax = new Vector2(child.anchorMax.x, pY);
				child.pivot = new Vector2(child.pivot.x, 0f);
				child.anchoredPosition = new Vector2(child.anchoredPosition.x, y);
				y += child.rect.height + _space;
			}

			if (_followParentRebuil && Rect.parent != null)
				LayoutRebuilder.MarkLayoutForRebuild((RectTransform) Rect.parent);
		}
	}
}