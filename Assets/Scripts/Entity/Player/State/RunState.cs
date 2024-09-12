namespace Mir.Entity.Player.State
{
    public class RunState : Animation.State
    {
        private float duration = .85f;

        public override void OnEnter(StateMachine stateMachine)
        {
            base.OnEnter(stateMachine);

            PlayerAnimation.Instance.RunState = true;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (time >= duration)
            {
                stateMachine.SetNextStateToMain();
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            PlayerAnimation.Instance.RunState = false;
        }
    }
}
