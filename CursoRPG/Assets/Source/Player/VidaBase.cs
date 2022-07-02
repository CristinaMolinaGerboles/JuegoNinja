using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] protected float _saludInicial;
    [SerializeField] protected float _saludMaxima;

    public float Salud{get; protected set;}//Propiedad de tipo float a la que le puedes hacer getter y setter
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Salud = _saludInicial;
    }

    public void RecibirDanio(float amount){
        if(amount > 0f){
            if(Salud > 0f){
                Salud -= amount;
                updateLife(Salud, _saludMaxima);
                if(Salud <= 0f){
                    updateLife(Salud, _saludMaxima);
                    muerte();
                }
            }
        }
    }
    protected virtual void updateLife(float saludActual, float saludMax){

    }
    protected virtual void muerte(){

    }
}
