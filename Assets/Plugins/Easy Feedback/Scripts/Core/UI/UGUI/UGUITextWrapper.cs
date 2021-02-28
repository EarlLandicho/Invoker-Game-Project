using System;
using UnityEngine.UI;

namespace EasyFeedback.Core.UI
{
	internal class UGUITextWrapper : UIInteropWrapper<Text>, IText
	{
		public string Text
		{
			get { return target.text; }
			set { target.text = value; }
		}

		public UGUITextWrapper(Text target) : base(target) { }
	}
}
