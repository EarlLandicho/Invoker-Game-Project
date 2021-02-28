using UnityEngine;

namespace EasyFeedback.Demo
{
    public class CauseException : MonoBehaviour
    {
        public void ThrowException()
        {
            throw new System.Exception("Test");
        }
    }
}
