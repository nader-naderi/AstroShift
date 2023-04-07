using UnityEngine;


namespace AstroShift
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private float shakeDuration = 0.2f;
        [SerializeField] private float shakeIntensity = 0.5f;

        private Vector3 desiredPosition;
        private Vector3 smoothVelocity;
        private float shakeTimer = 0f;

        private void LateUpdate()
        {
            if (target == null)
                return;

            desiredPosition = target.position + offset;

            if (shakeTimer > 0f)
            {
                desiredPosition += Random.insideUnitSphere * shakeIntensity;
                shakeTimer -= Time.deltaTime;
            }

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothVelocity, smoothSpeed);
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void ShakeCamera()
        {
            shakeTimer = shakeDuration;
        }
    }
}