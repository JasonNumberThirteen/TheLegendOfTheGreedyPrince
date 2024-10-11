using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDuck : MonoBehaviour
{
	[SerializeField] private Timer timer;
	
	private bool canDuck = true;

	private void Awake()
	{
		if(timer != null)
		{
			timer.timeElapsedEvent.AddListener(OnTimeElapsed);
		}
	}

	private void OnDestroy()
	{
		if(timer != null)
		{
			timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
		}
	}

	private void OnTimeElapsed()
	{
		SetDuckState(false);
	}
	
	private void OnDuck(InputValue inputValue)
	{
		if(canDuck)
		{
			SetDuckState(true);
		}
	}

	private void SetDuckState(bool duck)
	{
		canDuck = !duck;
		transform.localScale = LocalScale(duck);

		AdjustPosition(duck);
		
		if(duck && timer != null)
		{
			timer.Reset();
		}
	}

	private Vector3 LocalScale(bool duck)
	{
		var y = duck ? 0.5f : 1f;
		
		return new Vector3(transform.localScale.x, y, transform.localScale.z);
	}

	private void AdjustPosition(bool duck)
	{
		var direction = duck ? Vector2.down : Vector2.up;
		
		transform.Translate(direction*0.25f);
	}
}