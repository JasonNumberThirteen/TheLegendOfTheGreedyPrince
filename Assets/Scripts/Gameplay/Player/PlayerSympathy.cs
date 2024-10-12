using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSympathy : MonoBehaviour
{
    public UnityEvent<int, int> sympathyChangedEvent;
	
	private int currentSympathy = 500;

	public void ChangeSympathyBy(int Sympathy)
	{
		currentSympathy += Sympathy;

		sympathyChangedEvent?.Invoke(currentSympathy, Sympathy);
	}

	public int GetCurrentSympathy()
	{
		return currentSympathy;
	}
}
