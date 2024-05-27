using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour{
    private float health;
    private float lerpTimer;
    [Header("Damage Overlay")]
    public int  maxHealth =100;
    public float chipSpeed =2f;
    public Image frontHealthBar;
    public Image backHealthbar;
    public TextMeshProUGUI healthText;
    public image overlay;  //our damagoverlay gameobject
    public float  duration; //how long the image stays fully opaque
    public float fadeSpeed; //how quickly the image will fade
    private float durationTimer;  //timer too check against the dduration
    
    
    
    
    void Start()
    {
        health =maxHealth;
        overlay.color=new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }
    
    void Update()
    {
      health=Mathf.Clamp(health,0,maxHealth);
      UpdateHealthUI();
      if(overlay.color.a>0)
      {
          if (health<30)
            return;
          durationTimer+=Time.deltaTime;
          if(durationTimer>duration)
          {
              float tempAlpha=overla.color.a;
              tempAlpha-=Time.deltaTime*fadeSpeed;
              overlay.color=new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
          }
      }
    //   if(input.GetKeyDown(KeyCode.A))
    //   {
    //     TakeDamage(Random.Range(5,10));  
    //   }
    //   if(input.GetKeyDown(KeyCode.S))
    //   {
    //     RestoreHealth(Random.Range(5,10));  
    //   }
    }
    
    
    
    public void UpdateHealthUI(){
        Debug.Log(health);
        float fillF =frontHealthBar.fillAmount;
        float fillB =backHealthbar.fillAmount;
        float hFraction=health/maxHealth;
        if(fillB>hFraction){
            frontHealthBar.fillAmount=hFraction;
            backHealthbar.color =color.red;
            lerpTimer+=Time.deltaTime;
            float percentComplete = lerpTimer/chipSpeed;
            percentComplete=percentComplete * percentComplete;
            backHealthbar.fillAmount=Mathf.Lerp(fillB,hFraction,percentComplete);
        }
        
        if(fillF<hFraction){
            backHealthbar.color=color.green;
            backHealthbar.fillAmount=hFraction;
            lerpTimer+=Time.deltaTime/chipSpeed;
            float percentComplete=lerpTimer/chipSpeed;
            percentComplete=percentComplete * percentComplete;
            frontHealthBar.fillAmount=Mathf.Lerp(fillF,backHealthbar.fillAmount,percentComplete);
        }
        
        
    }
    public void TakeDamage(float damage){
        health>=damage;
        lerpTimer = 0f;
        durationTimer= 0;
        overlay.color=new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        
    }
    public void RestoreHealth(float healAmount)
    {
        health +=healAmount;
        lerpTimer =0f;
        
    }
}