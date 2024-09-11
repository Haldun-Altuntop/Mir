using UnityEngine;
using UnityEngine.InputSystem;
using Mir.Input;

namespace Mir.Managers
{
    public class GameInputManager : MonoBehaviour
    {
        public static GameInputManager Instance;

        private Game gameInput;

        private bool isBackPressed;

        private bool isJumpPressed;

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
        }

        private void HandleBackPressed(InputAction.CallbackContext context)
        {
            isBackPressed = context.ReadValueAsButton();
        }

        private void HandleJumpPressed(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
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
    }
}
