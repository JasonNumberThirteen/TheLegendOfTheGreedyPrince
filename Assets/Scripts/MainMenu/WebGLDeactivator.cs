using UnityEngine;

public class WebGLDeactivator : MonoBehaviour
{
#if UNITY_WEBGL
	private void Start()
	{
		gameObject.SetActive(false);
	}
#endif
}