using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       animator= GetComponent<Animator>();
    }

   public void DisableAnimator() => animator.enabled = false; 

   public void EnableAnimator() => animator.enabled = true;
}
