
using TMPro;
using UnityEngine.UI;

namespace EasyFeedback.Core.UI
{
	internal class UGUIDropdownWrapper 
		: UIInteropWrapper<Dropdown>, IDropdown
	{
		public IText CaptionText { get; private set; }

		public int Value
		{
			get
			{
				return target.value;
			}

			set
			{
				target.value = value;
			}
		}

		public UGUIDropdownWrapper(Dropdown target) : base(target)
		{
			CaptionText = new UGUITextWrapper(target.captionText);
		}

		public void ClearOptions()
		{
			target.ClearOptions();
		}

		public void RefreshShownValue()
		{
			target.RefreshShownValue();
		}

		public void AddOption(string text)
		{
			target.options.Add(new Dropdown.OptionData(text));
		}
	}
}