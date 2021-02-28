using System;
using TMPro;

namespace EasyFeedback.Core.UI
{
	internal class TMPTextWrapper : UIInteropWrapper<TMP_Text>, IText
	{
		public string Text
		{
			get { return target.text; }
			set { target.text = value; }
		}

		public TMPTextWrapper(TMP_Text target) : base(target) { }
	}
}
