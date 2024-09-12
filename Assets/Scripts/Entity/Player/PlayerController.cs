using Mir.Entity.Player.State;
using Mir.Managers;
using UnityEngine;

namespace Mir.Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private StateMachine stateMachine;

        void Start()
        {
            if (stateMachine != null) Debug.Log("State Machine boþ deðildi. Mevcut deðer kullanýlacak.");
            else stateMachine = GetComponent<StateMachine>();
        }

        void Update()
        {
            HandleMovement();
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (GameInputManager.Instance.Movement == Vector3.zero) stateMachine.SetMainState(new IdleState());
            else stateMachine.SetMainState(new RunState());

            stateMachine.SetNextStateToMain();
        }

        private void HandleMovement()
        {
            Vector3 movement = GameInputManager.Instance.Movement;
            if (movement != Vector3.zero)
            {
                transform.position += speed * Time.deltaTime * movement;
            }
        }
    }
}
