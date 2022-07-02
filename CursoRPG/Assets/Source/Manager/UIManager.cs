using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{

    //public static UIManager Instance;//Singleton

    [Header("Life")]
    [SerializeField] private Image playerLife;
    [SerializeField] private TextMeshProUGUI lifeTMP;
    
    [Header("Mana")]
    [SerializeField] private Image playerMana;
    [SerializeField] private TextMeshProUGUI manaTMP;
    // Start is called before the first frame update

    private float currenteLife;
    private float maxLife;

    private float currentMana;
    private float maxMana;

    private void Awake() {
        //Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
    }

    private void ActualizarUIPersonaje(){
        playerLife.fillAmount = Mathf.Lerp(playerLife.fillAmount, currenteLife/maxLife, 10f* Time.deltaTime);
        lifeTMP.text = $"{currenteLife}/{maxLife}";  

        playerMana.fillAmount =  Mathf.Lerp(playerMana.fillAmount, currentMana/maxMana, 10f* Time.deltaTime);
        manaTMP.text = $"{currentMana}/{maxMana}";  
    }

    public void ActualizarVidaPlayer(float pCurrentLife, float pMaxLife){
        currenteLife = pCurrentLife;
        maxLife = pMaxLife;
    }
    public void ActualizarManaPlayer(float pCurrentMana, float pMaxMana){
        currenteLife = pCurrentMana;
        maxLife = pMaxMana;
    }
}
