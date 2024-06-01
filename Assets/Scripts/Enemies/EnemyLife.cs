using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] int health = 100;
    private int currentHealth;
    private Animator animator;
    private Collider col;
    public event Action <float> OnEmemyHealthChanged;
    void Start()
    {
        col = GetComponent<Collider>();
       TryGetComponent<Animator>(out animator);
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {
        
        currentHealth += damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            float healthPercentage = (float)currentHealth / health;
            OnEmemyHealthChanged?.Invoke(healthPercentage);
            
        }
    }

    private void Die()
    {
         OnEmemyHealthChanged?.Invoke(0);
        gameObject.layer = LayerMask.NameToLayer("Default");
        col.enabled = false;
        if(animator!=null)
      {
      animator.enabled = false;
      }  
        
        EventBus.EnemyDefeated();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet") )
        {
            TakeDamage(-50);
        }
    }
}


