using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public abstract class BaseEvent
    {
        public event Action<BaseEvent, bool> Finished; 
        
        public virtual void Begin()
        {
            // Add UI, activate interactables etc
        }

        public virtual void End()
        {
            // Hide UI, give rewards etc
        }

        public virtual void Update()
        {
            // Called every frame
        }

        protected virtual void OnFail()
        {
            // Do something on event fail
            Finished?.Invoke(this, false);
        }

        protected virtual void OnComplete()
        {
            // Do something on event complete
            Finished?.Invoke(this, true);
        }

        protected virtual void OnProgress()
        {
            // Update UI, maybe trigger extra events etc
        }
    }
}