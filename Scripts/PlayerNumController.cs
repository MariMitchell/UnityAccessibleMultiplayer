using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumController : MonoBehaviour
{

    public int playerNum = 0;

    private GameObject manager;
    private PlayerManager texture;

    public GameObject body;
    public GameObject wheel1;
    public GameObject wheel2;

    public ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        texture = manager.GetComponent<PlayerManager>();
        GameObject me = this.gameObject;
        texture.AddPlayer(me);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTextures(Material mat1, Material mat2)
    {
        body.GetComponent<MeshRenderer>().material = mat1;
        wheel1.GetComponent<MeshRenderer>().material = mat1;
        wheel2.GetComponent<MeshRenderer>().material = mat1;
        particles.GetComponent<Renderer>().material = mat2;
    }
}
