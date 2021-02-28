using EasyFeedback.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace EasyFeedback
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class SetVersionText : MonoBehaviour
    {
        public string VersionNumber;
        public string Prefix, Suffix;

        // Use this for initialization
        void Start()
        {
            // set version text
            var text = UIInterop.GetText(gameObject);
            text.Text = Prefix + VersionNumber + Suffix;
        }
    }
}