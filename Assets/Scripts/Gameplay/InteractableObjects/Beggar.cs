using UnityEngine;

public class Beggar : MonoBehaviour, IClickableByPlayer
{
	[SerializeField] private int cost = -30;
    [SerializeField] private int sympathy = 300;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney) && sender.TryGetComponent(out PlayerSympathy playerSympathy))
		{
			if(playerMoney.GetCurrentMoney() + cost >= 0) {
                playerMoney.ChangeMoneyBy(cost);

                
                playerSympathy.ChangeSympathyBy(sympathy);
                    
                
            } 
            
			
		}
        
	}
}