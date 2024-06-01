using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerMovement playerMovement) : base(playerMovement) { }

    public override void Enter()
    {
        playerMovement.agent.isStopped = true;
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0)|| Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            playerMovement.ChangeState(new MovingState(playerMovement));
        }
       
    }

    public override void Exit()
    {
        playerMovement.agent.isStopped = false;
    }
}

