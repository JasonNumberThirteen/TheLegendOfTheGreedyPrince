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

		animator.SetBool("playerDown",true);

		//transform.localScale = LocalScale(duck);

		AdjustPosition(duck);
		
		if(duck && timer != null)
		{
			timer.Reset();
			playerDuckedEvent?.Invoke();
            
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