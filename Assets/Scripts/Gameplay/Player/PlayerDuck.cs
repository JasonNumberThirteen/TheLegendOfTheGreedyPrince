using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerDuck : MonoBehaviour
{
	[SerializeField] private Timer timer;

	public UnityEvent playerDuckedEvent;
	
	private bool canDuck = true;

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
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
		animator.SetBool("playerDown", false);
	}
	
	private void OnDuck(InputValue inputValue)
	{
		SetDuckState(true);
	}

	private void SetDuckState(bool duck)
	{
		if(canDuck != duck)
		{
			return;
		}
		
		canDuck = !duck;

		animator.SetBool("playerDown", canDuck);
		
		if(duck && timer != null)
		{
			timer.Reset();
			playerDuckedEvent?.Invoke();
		}
	}
}