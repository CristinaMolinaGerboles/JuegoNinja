using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerLife _playerLife { get; private set; }
    public PlayerMana _playerMana { get; private set; }

    private void Awake() {
        _playerLife = GetComponent<PlayerLife>();
        _playerMana = GetComponent<PlayerMana>();
    }

    public void RevivirPlayer(){
        _playerLife.RevivirPlayer();
        _playerMana.RestablecerMana();
    }
}