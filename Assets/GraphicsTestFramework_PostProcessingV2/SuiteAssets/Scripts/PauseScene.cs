using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphicsTestFramework
{
    public enum EventType { Start, Call }

    public class PauseScene : MonoBehaviour
    {
        public EventType eventType;

        public Animator[] animators;
        public ParticleSystem[] particleSystems;

        private void Start()
        {
            if (eventType == EventType.Start)
                Pause();
        }

        public void Pause()
        {
            foreach (Animator animator in animators)
                animator.speed = 0;
            foreach (ParticleSystem particleSystem in particleSystems)
                particleSystem.Pause();
        }
    }
}

