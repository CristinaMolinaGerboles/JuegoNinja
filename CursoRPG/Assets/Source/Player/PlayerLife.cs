using System;

using UnityEngine;
public class PlayerLife : VidaBase{
 
public static Action EventoMuertePlayer;
public static Action EventoRevivirPlayer;
    public bool Curar=> Salud < _saludMaxima;

    public bool muertePlayer { get; private set; }
    private BoxCollider2D _boxCollider2D;

    private void Awake() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    protected override void Start()
    {
        base.Start();
        updateLife(Salud, _saludMaxima);
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            RecibirDanio(10);
        }
    }

    public void RestaurarSalud(float amount){
        if(Curar){
            Salud += amount;
            if(Salud > _saludMaxima){
                Salud = _saludMaxima;
                updateLife(Salud, _saludMaxima);
            }
        }
    }

    protected override void updateLife(float saludActual, float saludMax){
        UIManager.Instance.ActualizarVidaPlayer(saludActual, saludMax);
    }
    protected override void muerte(){
        muertePlayer = true;
        _boxCollider2D.enabled = false;
        EventoMuertePlayer?.Invoke();
    }
    public void RevivirPlayer(){
        muertePlayer = false;
        _boxCollider2D.enabled = true;
        Salud = _saludInicial;
        updateLife(Salud, _saludMaxima);
        EventoRevivirPlayer?.Invoke();
    }

}
