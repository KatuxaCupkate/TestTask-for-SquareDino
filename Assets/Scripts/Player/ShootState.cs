using System.Linq.Expressions;
using UnityEngine;

public class ShootingState : PlayerState
{
    public ShootingState(PlayerMovement playerMovement) : base(playerMovement) { }
 
    public override void Enter()
    {
        playerMovement.agent.isStopped = true;
       
       
    }

    public override void Update() 
    {
         if (Input.GetMouseButtonDown(0)||Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
           Shoot(); 
           
         }
         else  if(playerMovement.FindeEnemies().Length <= 0||playerMovement.FindeEnemies()==null )
         {
           playerMovement.ChangeState(new MovingState(playerMovement)); 
         }
    
    }

    public override void Exit()
     {  
        playerMovement.agent.isStopped = false;
    }

    private void Shoot()
    {
       playerMovement.bulletPool.GetPooledObject().SetForce();       
    }

    
}
