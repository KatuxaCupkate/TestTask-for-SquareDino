using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private const string IsMoving = "isMoving";
    // Start is called before the first frame update
    void Start()
    {
        
    }

private void OnEnable() {
    EventBus.OnMovementStateChange += ChanegeAnimationState;
}
private void OnDisable() {
    EventBus.OnMovementStateChange -= ChanegeAnimationState;
}

    private void ChanegeAnimationState(bool state)
    {
        animator.SetBool(IsMoving, state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
