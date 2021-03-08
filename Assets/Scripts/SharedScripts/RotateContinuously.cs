#region

using UnityEngine;

#endregion

public class RotateContinuously : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 1;
	[SerializeField] private bool clockWise;

	private void Update()
	{
		if (!clockWise)
		{
			transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
		}
		else
		{
			transform.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed);
		}
	}
}