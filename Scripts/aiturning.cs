using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiturning : MonoBehaviour
{

    // public UnityEngine.AI.NavMeshAgent enemy;
    private float turnAmount = 15;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        int layerMask = 1 << 9;

        RaycastHit hit;

       

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 125, layerMask))
        {
            Debug.Log("hit");
            int turnDirection = Random.Range(0, 2);
            if (hit.transform.CompareTag("obstacle")){
                if (turnDirection == 0)
                {
                    rb.transform.Rotate(0, (1f * turnAmount), 0);

                }
                else if (turnDirection == 1)
                {
                    rb.transform.Rotate(0, (-1f * turnAmount), 0);

                }
            }
        }


       // enemy.SetDestination(GameObject.FindGameObjectWithTag("player").transform.position);
    }
}
