using UnityEngine;

namespace DefaultNamespace
{
    public class Moving : MonoBehaviour
    {
        [SerializeField] private float speed;
        private void Update()
        {
           float angle = speed * Time.deltaTime;
           transform.Rotate(Vector3.up, angle);
        }
    }
}