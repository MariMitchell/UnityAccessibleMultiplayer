using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private GameObject manager;

    private PlayerManager managerScript;

    private CustomGravityTest movementScript;

    public Camera playerCam;

    public GameObject[] wheels;

    private Turning turning;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        managerScript = manager.GetComponent<PlayerManager>();
        movementScript = gameObject.GetComponent<CustomGravityTest>();
        turning = gameObject.GetComponent<Turning>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Arena" && other.tag !="player")
        {
            Debug.Log("hit something");
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        turning.canTurn = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        foreach (GameObject wheel in wheels)
        {
            wheel.GetComponent<Rigidbody>().isKinematic = false;
            wheel.GetComponent<Rigidbody>().useGravity = true;
        }
        managerScript.UpdateDeadPlayers(gameObject);
        transform.DetachChildren();
        movementScript.forwardGo = 0;
        playerCam.GetComponent<PointCamAtPlayer>().playerDead = true;
    }

    public void Win(int playerNum)
    {
        text.text = "Player " + playerNum + " wins!";
        turning.canTurn = false;
        movementScript.forwardGo = 0;
    }

}
