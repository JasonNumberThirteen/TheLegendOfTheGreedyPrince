using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextUIFontSizeIncreaseEffect : MonoBehaviour
{
	[SerializeField, Min(0f)] private float targetFontSize = 64f;
	[SerializeField, Min(1f)] private float increaseSpeed = 30f;

	private TextMeshProUGUI text;
	private float initialFontSize;

	public void SetFontSize()
	{
		text.fontSize = targetFontSize;
	}

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
		initialFontSize = text.fontSize;
	}

	private void Update()
	{
		if(text.fontSize > initialFontSize)
		{
			text.fontSize -= Time.deltaTime*increaseSpeed;
		}
	}
}