using Mir.Animation;
using UnityEngine;

namespace Mir
{
    public class StateMachine : MonoBehaviour
    {
        private State mainState;
        private State currentState;
        private State nextState;

        void Start()
        {
        
        }

        public void SetState(State newState)
        {
            nextState = null;
            if (currentState != null) currentState.OnExit();
            currentState = newState;
            currentState.OnEnter(this);
        }

        public void SetNextState(State nextState)
        {
            if (nextState != null)
            {
                this.nextState = nextState;
            }
        }

        private void SetNextStateToMain()
        {
            nextState = mainState;
        }

        void Update()
        {
            if (nextState != null) 
                SetNextState(nextState);

            if (currentState != null) 
                currentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (currentState != null)
                currentState.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            if (currentState != null)
                currentState.OnLateUpdate();
        }
    }
}
