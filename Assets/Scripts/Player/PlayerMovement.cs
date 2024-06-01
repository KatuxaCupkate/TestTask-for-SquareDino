using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] private float enemyDetectionRadius = 10f;
    public NavMeshAgent agent;
    private PlayerState currentState;
    public int currentWaypointIndex {get;private set;}

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(new IdleState(this));
        currentWaypointIndex = 0;
    }

    void Update()
    {
        currentState.Update();
    }
 public void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0|| currentWaypointIndex == waypoints.Length-1)
        {
            EventBus.GetToLastWaypoint();
            return;
        }
        
        currentWaypointIndex ++;
        agent.destination = waypoints[currentWaypointIndex].position;
       
    }
    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public Collider[] FindeEnemies()
    {
       Collider[] enemies = Physics.OverlapSphere(transform.position, enemyDetectionRadius, enemyLayer);
      
       return enemies;
    }
}



