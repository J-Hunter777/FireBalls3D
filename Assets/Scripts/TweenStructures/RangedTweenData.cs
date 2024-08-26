using Assets.Scripts.TweenStructures;
using UnityEngine;

namespace TweenStructures
{
    [System.Serializable]
    public class Vector3RangedTweenData : RanhedTweenData<Vector3> { }
	
	[System.Serializable]
	public class Vector2RangedTweenData : RanhedTweenData<Vector2> { }
	public class RanhedTweenData<T> : TweenData <T>

	{
		public T From;
		public T To;
	}
}