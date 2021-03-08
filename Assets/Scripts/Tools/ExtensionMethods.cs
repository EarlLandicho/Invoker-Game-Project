#region

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#endregion

public static class ExtensionMethods
{
	public static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}

	public static Vector2 GetNormalizedDirectionToPlayer2D(GameObject currentObject)
	{
		GameObject playerObject = GameObject.Find("Player");
		return (playerObject.transform.position - currentObject.transform.position).normalized;
	}

	// min is inclusive and max is exclusive
	public static bool IsBetweenTwoValues(float min, float max, float value)
	{
		if (value >= min && value < max)
		{
			return true;
		}

		return false;
	}

	// min is inclusive and max is exclusive
	public static bool IsBetweenTwoValues(int min, int max, int value)
	{
		if (value >= min && value < max)
		{
			return true;
		}

		return false;
	}

	public static Vector3 GetPlayerPosition()
	{
		return GameObject.Find("Player").transform.position;
	}

	public static string PrintListElements<T>(List<T> list)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		foreach (T item in list)
		{
			stringBuilder.Append(item + " ");
		}

		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}