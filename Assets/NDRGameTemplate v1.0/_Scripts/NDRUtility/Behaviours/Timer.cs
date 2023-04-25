using UnityEngine;
using System.Collections;
using System;

namespace NDRUtil
{
    public class Timer : MonoBehaviour
    {
        public float RemainingSeconds { get; private set; }

        public Timer(float duration)
        {
            RemainingSeconds = duration;
        }

        public event System.Action OnTimerEnds;

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0) return;

            RemainingSeconds -= deltaTime;

            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0) return;

            RemainingSeconds = 0f;

            OnTimerEnds?.Invoke();
        }
    }
}