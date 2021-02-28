using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyFeedback.Core.UI
{
	internal class UGUIInputFieldWrapper
		: UIInteropWrapper<InputField>, IInputField
	{
		public UGUIInputFieldWrapper(InputField target) : base(target) { }

		public UnityEvent<string> OnValueChanged
		{
			get { return target.onValueChanged; }
		}

		public string Text
		{
			get { return target.text; }
			set
			{
				target.text = value;
			}
		}

		public bool IsFocused
		{
			get { return target.isFocused; }
		}

		public void ActivateInputField()
		{
			target.ActivateInputField();
		}

		public void DeactivateInputField()
		{
			target.DeactivateInputField();
		}
	}
}