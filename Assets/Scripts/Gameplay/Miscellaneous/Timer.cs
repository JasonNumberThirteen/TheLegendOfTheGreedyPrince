using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public UnityEvent timeElapsedEvent;

	[SerializeField, Min(0f)] private float target = 1f;
	[SerializeField] private bool isRepetetive;

	private float currentTime;
	private bool timeElapsed;

	private void Update()
	{
		if(currentTime < target)
		{
			currentTime += Time.deltaTime;
		}
		else if(!timeElapsed)
		{
			if(isRepetetive)
			{
				currentTime = 0f;
			}
			else
			{
				timeElapsed = true;
			}

			timeElapsedEvent?.Invoke();
		}
	}
}