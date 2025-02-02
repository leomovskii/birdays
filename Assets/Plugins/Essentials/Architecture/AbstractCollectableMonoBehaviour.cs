using System.Collections.Generic;
using UnityEngine;

namespace Essentials {
	public abstract class AbstractCollectableMonoBehaviour<T> : MonoBehaviour where T : AbstractCollectableMonoBehaviour<T> {

		protected readonly static List<T> _list = new List<T>();

		protected virtual void OnEnable() {
			if (this is T item)
				_list.Add(item);
		}

		protected virtual void OnDisable() {
			if (this is T item)
				_list.Remove(item);
		}
	}
}