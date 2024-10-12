using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class ImagesUIFaderIn : MonoBehaviour
{
	[SerializeField] private Image[] images;

	private Timer timer;

	private void Awake()
	{
		timer = GetComponent<Timer>();
	}

	private void Start()
	{
		foreach (var image in images)
		{
			image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
		}
	}

	private void Update()
	{
		foreach (var image in images)
		{
			image.color = ImageColor(image);
		}
	}

	private Color ImageColor(Image image)
	{
		var color = image.color;
		var timerTarget = timer.GetTarget();
		var alpha = timerTarget > 0 ? timer.GetCurrentTime() / timerTarget : 1;

		return new Color(color.r, color.g, color.b, alpha);
	}
}