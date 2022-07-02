using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private Transform respawnPoint;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            if(player._playerLife.muertePlayer){
                player.transform.localPosition = respawnPoint.position;
                player.RevivirPlayer();
            }
        }
    }
}