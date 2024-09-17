using UnityRandom = UnityEngine.Random;

namespace Scripts.Structures
{
    [System.Serializable]
    public class FloatRange : Range<float>
    {
        public float Random => UnityRandom.Range(Min, Max);
    }
}
