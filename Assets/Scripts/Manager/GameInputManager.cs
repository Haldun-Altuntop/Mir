using UnityEngine;
using UnityEngine.InputSystem;
using Mir.Input;
using System;

namespace Mir.Managers
{
    public class GameInputManager : MonoBehaviour
    {
        public static GameInputManager Instance;

        private Game gameInput;

        private bool isBackPressed;

        private bool isJumpPressed;
        private Vector3 movement;

        private void Awake()
        {
            if (Instance != null) Debug.LogError("Found more than one Game Input Manager in the scene!");
            Instance = this;

            gameInput = new Game();
        }

        private void Start()
        {
            gameInput.GameActions.Back.started += HandleBackPressed;

            gameInput.PlayerActions.Jump.started += HandleJumpPressed;

            gameInput.PlayerActions.Movement.performed += HandleMovement;
            //gameInput.PlayerActions.Movement.canceled += SetMovementToZero;
        }

        private void HandleBackPressed(InputAction.CallbackContext context)
        {
            isBackPressed = context.ReadValueAsButton();
        }

        private void HandleJumpPressed(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        private void HandleMovement(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector3>();
        }

        private void SetMovementToZero(InputAction.CallbackContext context)
        {
            movement = Vector3.zero;
        }

        public void DisablePlayerInput()
        {
            gameInput.PlayerActions.Disable();
        }

        public void EnablePlayerInput()
        {
            gameInput.PlayerActions.Enable();
        }

        private void OnEnable()
        {
            gameInput.GameActions.Enable();
            EnablePlayerInput();
        }

        private void OnDisable()
        {
            gameInput.GameActions.Disable();
            DisablePlayerInput();
        }

        public bool IsBackPressed
        {
            get
            {
                bool tmp = isBackPressed;
                isBackPressed = false;
                return tmp;
            }
        }

        public bool IsJumpPressed
        {
            get
            {
                bool tmp = isJumpPressed;
                isJumpPressed = false;
                return tmp;
            }
        }

        public Vector3 Movement
        {
            get
            {
                return movement;
            }
        }
    }
}
