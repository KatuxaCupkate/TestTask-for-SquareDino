using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PooledObject : MonoBehaviour
{
    [SerializeField] public float speed = 20f;
     private Transform pooledObjectTransform;
      public ObjectPool  Pool { get => pool; set => pool = value; }
    private ObjectPool pool;
   public Rigidbody pooledObjectRb;

    // Start is called before the first frame update
    void Start()
    {   
        pooledObjectRb = GetComponent<Rigidbody>();
        pooledObjectTransform= pool.transform;
    }


    public Vector3 GetTapPosition()
    {
        Vector3 tapPosition = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                tapPosition = hit.point;
            }
        
         if (Application.isMobilePlatform)
        {
            Ray rayMobile = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(rayMobile, out RaycastHit hitM))
            {
                tapPosition = hitM.point;
            }
        }
        return tapPosition;
    }


    public void SetForce()
    {
       transform.position = pool.poolTransform.position;
        var targetPosition = GetTapPosition();
        Vector3 direction =(targetPosition - pool.poolTransform.position).normalized; 
        pooledObjectRb.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision other) 
    {
        Pool.ReturnToPool(this);
    }
}
