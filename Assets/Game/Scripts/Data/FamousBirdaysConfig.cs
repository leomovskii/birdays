using System.Collections.Generic;
using UnityEngine;

namespace Birdays {
	[CreateAssetMenu(menuName = "Configurations/Famous Config")]
	public class FamousBirdaysConfig : ScriptableObject {

		[System.Serializable]
		public class Entry {

			[SerializeField] private string _name;
			[SerializeField] private Vector3Int _date;
			[SerializeField] private string _reference;

			public string Name => _name;
			public Vector3Int Date => _date;
			public string Reference => _reference;

		}

		[SerializeField] private Entry[] _entries;

		public List<List<Entry>> Entries {
			get {
				var sortedEntries = new List<List<Entry>>();
				for (int i = 0; i < 12; i++)
					sortedEntries.Add(new List<Entry>());

				for (int i = 0; i < _entries.Length; i++)
					sortedEntries[_entries[i].Date.y - 1].Add(_entries[i]);

				for (int i = 0; i < 12; i++)
					sortedEntries[i].Sort((a, b) => string.Compare(a.Name, b.Name));

				return sortedEntries;
			}
		}
	}
}