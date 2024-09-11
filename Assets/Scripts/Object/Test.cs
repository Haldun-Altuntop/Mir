using Mir.Managers;
using UnityEngine;

namespace Mir.Object
{
    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.Instance.IsBackPressed)
            {
                Debug.Log("Geri tuþuna basýldý.");
            }
    }
    }
}
