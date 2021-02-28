
using TMPro;
using UnityEngine.UI;

namespace EasyFeedback.Core.UI
{
	internal class TMPDropdownWrapper 
		: UIInteropWrapper<TMP_Dropdown>, IDropdown
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

		public TMPDropdownWrapper(TMP_Dropdown target) : base(target)
		{
			CaptionText = new TMPTextWrapper(target.captionText);
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
			target.options.Add(new TMP_Dropdown.OptionData(text));
		}
	}
}