using System;
using UnityEngine;

namespace EasyFeedback.Core.UI
{
	internal interface IDropdown
	{
		IText CaptionText { get; }
		int Value { get; set; }

		void ClearOptions();
		void RefreshShownValue();
		void AddOption(string text);
	}
}
