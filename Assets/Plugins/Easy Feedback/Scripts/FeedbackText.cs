using EasyFeedback.Core.UI;
using UnityEngine;

namespace EasyFeedback
{
#if UNITY_EDITOR
	[ExecuteInEditMode]
#endif
	public class FeedbackText : MonoBehaviour
	{
		public string Message = "Press {0} to submit feedback.";
		public FeedbackForm Form;
		private IText text;

		private KeyCode currentKey;

		private void Awake()
		{
			text = UIInterop.GetText(gameObject);
		}

		// Update is called once per frame
		void Update()
		{
			if (Form != null && currentKey != Form.FeedbackKey)
				UpdateText();
		}

		private void UpdateText()
		{
			currentKey = Form.FeedbackKey;
			text.Text = string.Format(Message, Form.FeedbackKey);
		}
	}
}