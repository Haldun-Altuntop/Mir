using UnityEngine;

namespace Mir
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animator;

        public static PlayerAnimation Instance;

        private void Awake()
        {
            if (Instance != null) Debug.LogError("Found mor than one Player Animation in the scene.");
            Instance = this;
        }

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public bool RunState
        {
            set
            {
                animator.SetBool("run", value);
            }

            get
            {
                return animator.GetBool("run");
            }
        }
    }
}
