using UnityEngine;
using Random = UnityEngine.Random;

namespace Karting.Scripts.Track
{
    
    public class Target : MonoBehaviour
    {
        private int _timer;
        public float interval;
        public Transform kartPos;

        private void Update()
        {
            var forward = kartPos.forward;
            var epic = forward / Vector3.Magnitude(forward);
            var up = kartPos.up;
            var epic2 = up / Vector3.Magnitude(up);
            
            _timer++;
            if (_timer % interval == 0f)
            {
                GetComponent<Renderer>().enabled = true;
                GetComponent<Renderer>().material.color = Color.red;
                var transform1 = transform;
                var position = kartPos.position;
                position += (11 * epic) + (3 * epic2) + (Random.insideUnitSphere * 3);
                transform1.position = position;
            }
        }
    }
}