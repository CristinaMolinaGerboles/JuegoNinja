using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private PlayerMovement _movimiento;

    private readonly int direccionX = Animator.StringToHash("X"); 
    private readonly int direccionY = Animator.StringToHash("Y"); 
    private readonly int muerte = Animator.StringToHash("Muerto"); 

    private void Awake(){
        _animator = GetComponent<Animator>();
        _movimiento = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        ActualizarLayer();
        if(!_movimiento.EnMoviento){
            return;
        }
        _animator.SetFloat(direccionX, _movimiento.DireccionMov.x);
        _animator.SetFloat(direccionY, _movimiento.DireccionMov.y);
    }

    private void ActivarLayer(string layerName){
        for(int i = 0; i < _animator.layerCount; ++i){
            _animator.SetLayerWeight(i,0);//Desactivar todos los layers
        }
        //Activamos solo el layer que queremos
         _animator.SetLayerWeight(_animator.GetLayerIndex(layerName),1);
    }

    private void ActualizarLayer(){
        if(_movimiento.EnMoviento){
            ActivarLayer(layerCaminar);
        }else{
            ActivarLayer(layerIdle);
        }
    }
    private void RespuestaMuerte(){
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1){
                 _animator.SetBool(muerte, true);
        }
    }
    private void RespuestaRevivir(){
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1){
                    _animator.SetBool(muerte, false);
        }
    }
    private void OnEnable() {
        PlayerLife.EventoMuertePlayer += RespuestaMuerte;
        PlayerLife.EventoRevivirPlayer += RespuestaRevivir;
    }
    private void OnDisable() {
       PlayerLife.EventoMuertePlayer -= RespuestaMuerte;
        PlayerLife.EventoRevivirPlayer -= RespuestaRevivir;
    }
}
