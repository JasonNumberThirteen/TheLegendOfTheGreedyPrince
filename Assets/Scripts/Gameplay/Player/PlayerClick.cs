using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClick : MonoBehaviour
{
	private void OnClick(InputValue inputValue)
	{
		var mousePosition = Mouse.current.position.ReadValue();
		var ray = Camera.main.ScreenPointToRay(mousePosition);
		var hit = Physics2D.GetRayIntersection(ray);

		if(hit.collider != null)
		{
			var hitGO = hit.collider.gameObject;

			if(hitGO.TryGetComponent(out IClickableByPlayer clickableByPlayer))
			{
				clickableByPlayer.OnClickByPlayer(gameObject, hitGO);
			}
		}
	}
}