using Mir.Animation;
using Mir.Entity.Player.State;
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
            mainState = new IdleState();
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

        public void SetNextStateToMain()
        {
            nextState = mainState;
        }

        public void SetMainState(State state)
        {
            mainState = state;  
        }

        void Update()
        {
            if (nextState != null) 
                SetState(nextState);

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
