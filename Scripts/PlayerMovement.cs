using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravityTest : MonoBehaviour
{
    public Rigidbody cubeBody;
    public float forwardGo = 30;
    public GameObject groundingBox;

    // Start is called before the first frame update
    void Start()
    {
        cubeBody = gameObject.GetComponent<Rigidbody>();
        cubeBody.maxLinearVelocity = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //cubeBody.velocity = (transform.up * -15) + (transform.forward * forwardGo);
        cubeBody.AddForce((transform.up * -5) + (transform.forward * forwardGo)) ;

        
    }

    private void FixedUpdate()
    {

        int layerMask = 1 << 8;

        RaycastHit hit;

        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.down), out hit, layerMask))
        {
            //Debug.Log("hit");
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }


}
