using UnityEngine;

namespace Mir.Animation
{
    public abstract class State
    {
        protected float time {  get; set; }
        protected float fixedTime {  get; set; }
        protected float lateTime {  get; set; }

        protected StateMachine stateMachine { get; set; }

        public virtual void OnEnter(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void OnUpdate()
        {
            time += Time.deltaTime;
        }

        public virtual void OnFixedUpdate()
        {
            fixedTime += Time.deltaTime;
        }

        public virtual void OnLateUpdate()
        {
            fixedTime += Time.deltaTime;
        }

        public virtual void OnExit()
        {
            time = 0f;
            fixedTime = 0f;
            lateTime = 0f;
        }
    }
}
