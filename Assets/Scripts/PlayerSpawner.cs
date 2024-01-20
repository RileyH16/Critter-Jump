
using StarterAssets;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public FollowPlayer followPlayer;
    public UICanvasControllerInput input;
    

    private void Start()
    {
        GameObject player = Instantiate(GameManager.instance.currentCharacter.prefab, transform.position, Quaternion.identity);
        followPlayer.player = player.transform;
        input.starterAssetsInputs = player.GetComponent<PlayerController>();
    }

 
}      
