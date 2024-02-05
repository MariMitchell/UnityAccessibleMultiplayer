using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public Material[] playerMaterials;
    public Material[] particleMaterials;
    private List<GameObject> livingPlayers = new List<GameObject>();

    private int totalPlayers = 0;
    private int deadPlayers = 0;

    public GameObject[] startPoints;

    private PlayerNumController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddPlayer(GameObject player)
    {
        livingPlayers.Add(player);
        int material = livingPlayers.IndexOf(player);
        //player.GetComponent<MeshRenderer>().material = playerMaterials[material];

        totalPlayers++;
        controller = player.GetComponent<PlayerNumController>();
        controller.UpdateTextures(playerMaterials[material], particleMaterials[material]);
        controller.playerNum = totalPlayers;
        player.transform.position = startPoints[totalPlayers - 1].transform.position;
        player.transform.rotation = startPoints[totalPlayers - 1].transform.rotation;
    }

    public void UpdateDeadPlayers(GameObject player)
    {
        Debug.Log("A player has died");
        livingPlayers.Remove(player);
        Debug.Log(livingPlayers);
        deadPlayers++;
        if (totalPlayers > 1 && deadPlayers == totalPlayers - 1)
        {
            livingPlayers[0].GetComponent<PlayerDeath>().Win(livingPlayers[0].GetComponent<PlayerNumController>().playerNum);
        }
    }
}
