using UnityEngine;

namespace Essentials {
	public static class IntFlagUtility {

		public readonly static int MaxFlagsCount = 32;

		public static int Pack(bool[] flags) {
			if (flags == null) {
				Debug.LogError("Flags array is null. Returning 0.");
				return 0;
			}

			if (flags.Length > MaxFlagsCount)
				Debug.LogWarning($"Flags array length exceeds MaxFlagsCount ({MaxFlagsCount}). Extra flags will be ignored.");

			int packedFlags = 0;
			for (int i = 0; i < Mathf.Min(flags.Length, MaxFlagsCount); i++)
				if (flags[i])
					packedFlags |= (1 << i);
			return packedFlags;
		}

		public static bool[] Unpack(int packedFlags) {
			var flags = new bool[MaxFlagsCount];
			for (int i = 0; i < MaxFlagsCount; i++)
				flags[i] = (packedFlags & (1 << i)) != 0;
			return flags;
		}

		public static int ModifyFlag(int packedFlags, int flagIndex, bool newFlagState) {
			if (flagIndex < 0 || flagIndex > MaxFlagsCount) {
				Debug.LogError($"Flag index out of range [0..{MaxFlagsCount}]. Operation will be ignored. Input = {flagIndex}");
				return packedFlags;
			}
			if (newFlagState)
				packedFlags |= (1 << flagIndex);
			else
				packedFlags &= ~(1 << flagIndex);
			return packedFlags;
		}

		public static bool HasAtLeastOtherFlag(int packedFlags, int excludeFlagIndex) {
			var flags = Unpack(packedFlags);
			for (int i = 0; i < MaxFlagsCount; i++)
				if (i != excludeFlagIndex && flags[i])
					return true;
			return false;
		}
	}
}