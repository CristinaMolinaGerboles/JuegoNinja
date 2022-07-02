using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{

    [SerializeField] private float _manaInicial;
    [SerializeField] private float _maxMana;
    [SerializeField] private float _regeneracionPorSec;
    
    private PlayerLife _playerLife;
    public float CurrentMana { get; private set; }
    
    private void Awake() {
        _playerLife = GetComponent<PlayerLife>();
    }
    void Start()
    {
        CurrentMana = _manaInicial;
        ActualizarManaPlayer();

        InvokeRepeating(nameof(RecoverMana), 1,1);//Llama al metodo regenerar 1 vez cada 1 segundo
    }
    private void Update() {
    }

    public void UseMana(float howmuch){
        if(CurrentMana >= howmuch){
            CurrentMana -= howmuch;
            ActualizarManaPlayer();
        }
    }
    public void RecoverMana(){
        if(_playerLife.Salud>0f && CurrentMana < _maxMana){
            CurrentMana += _regeneracionPorSec;
            if(CurrentMana > _maxMana){
                CurrentMana = _maxMana;
            }

            ActualizarManaPlayer();
        }
    }
    public void RestablecerMana(){//Restaura toda la mana del personaje al morir
        CurrentMana = _maxMana;
        ActualizarManaPlayer();
    }
    private void ActualizarManaPlayer(){
        UIManager.Instance.ActualizarManaPlayer(CurrentMana, _maxMana);
    }
}
