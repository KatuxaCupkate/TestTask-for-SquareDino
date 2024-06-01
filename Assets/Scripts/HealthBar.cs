using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarFilling;
     [SerializeField] private EnemyLife enemyLife;
    // Start is called before the first frame update

    void Start()    
    {
        healthBarFilling = transform.GetChild(0).GetComponent<Image>(); 
       
    }
    private void OnEnable() {
        enemyLife.OnEmemyHealthChanged += ChangeHealthBar;
       
    }
    private void OnDisable() {
        enemyLife.OnEmemyHealthChanged -= ChangeHealthBar;
      
    }
   public void ChangeHealthBar(float valueAsPercentage)
   {
       Debug.Log("HealthBar: " + valueAsPercentage);
       healthBarFilling.fillAmount = valueAsPercentage;
       if (valueAsPercentage == 0)
       {
           DisableHealthBar();
       }
   }

   public void DisableHealthBar() => gameObject.SetActive(false);
}
