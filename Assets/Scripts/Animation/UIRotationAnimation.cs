using UnityEngine;

namespace Animation
{
	public class UIRotationAnimation : MonoBehaviour
	{
        [SerializeField] private float speed;
        private void Update() => 
            Rotate(speed);

        private void Rotate(float speed1)
        {
            float angle = speed1 * Time.deltaTime;
            transform.Rotate(Vector3.forward, angle);
        }
    }
}

		