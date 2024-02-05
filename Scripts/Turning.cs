using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turning : MonoBehaviour
{

    private float turnAmount = 0;
    public Rigidbody rb;
    public bool canTurn = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTurn) { rb.transform.Rotate(0, (1f * turnAmount), 0); }
    }

    private void OnMove(InputValue turnValue)
    {
        Vector2 turnVector = turnValue.Get<Vector2>();

        turnAmount = turnVector.x;
        Debug.Log(turnAmount);
        //rb.transform.Rotate(0, 90f * turnAmount, 0);
    }
}
