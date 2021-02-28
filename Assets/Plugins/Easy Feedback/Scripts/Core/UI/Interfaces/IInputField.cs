using UnityEngine.Events;

namespace EasyFeedback.Core.UI
{
	internal interface IInputField
	{
		UnityEvent<string> OnValueChanged { get; }
		string Text { get; set; }
		bool IsFocused { get; }

		void ActivateInputField();
		void DeactivateInputField();
	}
}