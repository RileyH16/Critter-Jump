
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public FollowPlayer followPlayer;

    private void Start()
    {
        followPlayer.player = Instantiate(GameManager.instance.currentCharacter.prefab, transform.position, Quaternion.identity).transform;
        
    }

    
}
