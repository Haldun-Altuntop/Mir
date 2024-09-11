using UnityEngine;
using UnityEngine.InputSystem;
using Mir.Input;

namespace Mir.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        private Game gameInput;

        private bool isBackPressed;

        private void Awake()
        {
            if (Instance != null) Debug.LogError("Found more than one Input Manager in the scene!");
            Instance = this;

            gameInput = new Game();
        }

        private void Start()
        {
            gameInput.GameActions.Back.started += HandleBackPressed;
        }

        private void HandleBackPressed(InputAction.CallbackContext context)
        {
            isBackPressed = context.ReadValueAsButton();
        }

        private void OnEnable()
        {
            gameInput.GameActions.Enable();
        }

        private void OnDisable()
        {
            gameInput.GameActions.Disable();
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
    }
}
