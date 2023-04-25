using UnityEngine;

namespace NDRUtil
{
    public class BounceAnimation : MonoBehaviour
    {
        [SerializeField] Vector3 posOffset;
        [SerializeField] private float bounceSpeed = 8f;
        [SerializeField] private float bounceAmplitude = 0.05f;
        [SerializeField] private float rotationSpeed = 90f;
        
        private float startingHeight;
        private float timeOffset;

        private void Start()
        {
            startingHeight = transform.localScale.y;
            timeOffset = Random.value * Mathf.PI * 2;
        }

        private void Update()
        {
            HandleBouncing();
            HandleSpining();
        }

        private void HandleSpining()
        {
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.y += rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }

        private void HandleBouncing()
        {
            float finalHeight = startingHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
            var position = transform.localPosition;
            position.y = finalHeight;
            transform.localPosition = position + posOffset;
        }
    }
}
