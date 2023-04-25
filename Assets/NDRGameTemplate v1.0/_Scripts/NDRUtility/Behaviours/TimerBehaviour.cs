using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace NDRUtil
{
    public class TimerBehaviour : MonoBehaviour
    {
        [SerializeField] bool destroyOnEnd = true;
        [SerializeField] private float duration = 1f;
        [SerializeField] UnityEvent onTimerEnds = null;
        private Timer timer;
        private void Start()
        {
            timer = new Timer(duration);

            timer.OnTimerEnds += HandleTimerEnd;
        }

        private void HandleTimerEnd()
        {
            onTimerEnds.Invoke();
            if(destroyOnEnd)
            Destroy(this);
        }

        private void Update()
        {
            timer.Tick(Time.deltaTime);
        }
    }
}