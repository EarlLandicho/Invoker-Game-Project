using System;
using UnityEngine;

namespace EasyFeedback.Core.UI
{
	internal abstract class UIInteropWrapper<T> : IUIInteropWrapper
		where T : Component
	{
		public static Type TargetType { get { return typeof(T); } }

		public static T GetTarget(GameObject go)
		{
			return go.GetComponent<T>();
		}

		protected T target;

		public Component Target { get { return target; } }

		internal UIInteropWrapper(T target)
		{
			this.target = target;
		}
	}
}