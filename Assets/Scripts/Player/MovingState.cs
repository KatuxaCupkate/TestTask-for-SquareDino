using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    public MovingState(PlayerMovement playerMovement) : base(playerMovement) { }

    public override void Enter()
    {
        playerMovement.MoveToNextWaypoint();
       EventBus.MovementStateChange(true);     
    }

    public override void Update()
    {
        if (!playerMovement.agent.pathPending && playerMovement.agent.remainingDistance < 0.2f)
        {
            playerMovement.ChangeState(new ShootingState(playerMovement));
            EventBus.MovementStateChange(false);
        }
    }

    public override void Exit() { }
}

