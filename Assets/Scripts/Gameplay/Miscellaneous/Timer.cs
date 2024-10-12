using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public UnityEvent timeElapsedEvent;

	[SerializeField, Min(0f)] private float target = 1f;
	[SerializeField] private bool isEnabledOnStart = true;
	[SerializeField] private bool isRepetetive;

	private float currentTime;
	private bool timeElapsed;
	private bool isEnabled;

	public void Reset()
	{
		currentTime = 0f;
		timeElapsed = false;
	}

	public void SetEnabled(bool enabled)
	{
		isEnabled = enabled;
	}

	public float GetCurrentTime()
	{
		return currentTime;
	}

	public float GetTarget()
	{
		return target;
	}

	private void Start()
	{
		SetEnabled(isEnabledOnStart);
	}

	private void Update()
	{
		if(!isEnabled)
		{
			return;
		}
		
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