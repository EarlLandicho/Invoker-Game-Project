using UnityEngine;
using UnityEngine.Networking;

namespace EasyFeedback.Core.Web
{
#pragma warning disable CS0618
    public struct AsyncWebRequestData
    {
        /// <summary>
        /// The underlying UnityWebRequest
        /// </summary>
        public UnityWebRequest Request
        {
            get
            {
                return _request;
            }
        }
        private UnityWebRequest _request;

        /// <summary>
        /// The AsyncOperation for this request
        /// </summary>
        public AsyncOperation Operation
        {
            get { return _operation; }
        }
        public AsyncOperation _operation;

        /// <summary>
        /// Whether or not the async operation is finished
        /// </summary>
        public bool OperationIsDone
        {
            get { return Operation.isDone; }
        }

        /// <summary>
        /// Whether or not the request has resulted in an error
        /// </summary>
        public bool RequestIsError
        {
            get
            {
#if UNITY_2017_2_OR_NEWER
                return Request.isHttpError || Request.isNetworkError;
#else
                return Request.isError;
#endif
            }
        }

        public string ErrorText
        {
            get
            {
#if UNITY_2017_2_OR_NEWER
                if (Request.isHttpError) 
                {
                    return Request.downloadHandler.text;
                }
#endif

                if (RequestIsError)
                {
                    return Request.error;
                }

                return string.Empty;
            }
        }

        public AsyncWebRequestData(UnityWebRequest request, AsyncOperation operation)
        {
            _request = request;
            _operation = operation;
        }
    }
}