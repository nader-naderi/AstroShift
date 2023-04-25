using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace NDRGameTemplate
{
    public class CubeBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform m_Transform;
        [SerializeField] private Vector3 targetScale;

        private Vector3 desiredScale;
        
        private void Awake()
        {
            m_Transform = transform;
        }
        private void Update()
        {
            m_Transform.localScale = Vector3.Lerp(m_Transform.localScale, desiredScale, Time.deltaTime * 2);

            //if (m_Transform.localScale > targetScale)
            //{

            //}
        }
    }
}