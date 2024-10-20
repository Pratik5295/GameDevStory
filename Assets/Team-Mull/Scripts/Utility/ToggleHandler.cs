using UnityEngine;

namespace DevStory.Utility
{
    /// <summary>
    /// A Generic script to handle simple toggle in hierarchy
    /// </summary>
    public class ToggleHandler : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        public void ToggleActive()
        {
            if (target != null)
            {
                target.SetActive(!target.activeSelf);
            }
        }
    }
}
