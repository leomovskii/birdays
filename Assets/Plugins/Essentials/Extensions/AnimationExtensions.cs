using System.Threading.Tasks;
using UnityEngine;

namespace Essentials {
	public static class AnimationExtensions {

		public async static void Pause(this Animator origin, float time) {
			if (origin == null)
				Debug.LogError("Animator reference is null.");

			else if (time <= 0)
				Debug.LogError($"Animator can't pause on zero or negative time (input = {time}).");

			else {
				var speed = origin.speed;
				var milis = (int) (time * 1000);

				origin.speed = 0f;
				await Task.Delay(milis);
				origin.speed = speed;
			}
		}
	}
}