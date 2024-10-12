using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerDuck : MonoBehaviour
{
	[SerializeField] private Timer timer;
	[SerializeField] private Vector2 colliderOffsetWhenDucked;
	[SerializeField] private Vector2 colliderSizeWhenDucked;

	public UnityEvent playerDuckedEvent;
	
	private bool canDuck = true;

	private Animator animator;
	private BoxCollider2D boxCollider2D;
	private Vector2 initialColliderOffset;
	private Vector2 initialColliderSize;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		boxCollider2D = GetComponent<BoxCollider2D>();
		initialColliderOffset = boxCollider2D.offset;
		initialColliderSize = boxCollider2D.size;

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
		boxCollider2D.offset = duck ? colliderOffsetWhenDucked : initialColliderOffset;
		boxCollider2D.size = duck ? colliderSizeWhenDucked : initialColliderSize;

		animator.SetBool("playerDown", true);
		
		if(duck && timer != null)
		{
			timer.Reset();
			playerDuckedEvent?.Invoke();
		}
	}
}