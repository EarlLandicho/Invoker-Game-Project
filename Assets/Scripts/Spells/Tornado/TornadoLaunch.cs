#region

using UnityEngine;

#endregion

public class TornadoLaunch : MonoBehaviour
{
	[SerializeField] private GameObject tornado;
	private ComboBar comboBar;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		if (comboBar.GetComboBarStage() == 4)
		{
			GameObject obj = Instantiate(tornado, transform.position, transform.rotation);
			obj.GetComponent<Tornado>().SetIsReversed();
			obj.transform.Rotate(0f, 180, 0);
		}
		Instantiate(tornado, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}