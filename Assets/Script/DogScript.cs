using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogScript : MonoBehaviour
{
    public bool CanBePicked = false;
    private Transform gamePlayer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            CanBePicked = true;
        gamePlayer = collision.transform;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            CanBePicked = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanBePicked == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DogsManager.DogNumber -= 1;
                //Destroy(gameObject);

                GetComponent<NavMeshAgentMover>().enabled = true;
                GetComponent<NavMeshAgentMover>().target = gamePlayer;
                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<DogScript>().enabled = false;
            }
        }
    }
}
