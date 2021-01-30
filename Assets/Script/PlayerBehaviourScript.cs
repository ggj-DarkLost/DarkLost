using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public string PlayerCondition;
    //PlayerConditions: default, UnderSpot, Vanishing
    public float TimeCountSet;
    public float TimeCount;
    [Space]
    public GameObject PlayerActiveCollider;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDetector")
        {
            PlayerCondition = "UnderSpot";
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDetector")
        {
            PlayerCondition = "default";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerCondition = "default";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCondition == "UnderSpot")
        {
            TimeCount -= Time.deltaTime;
            if (PlayerActiveCollider.activeInHierarchy == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlayerActiveCollider.SetActive(true);
                }
            }
        }
        else
        {
            TimeCount = TimeCountSet;
            PlayerActiveCollider.SetActive(false);
        }

        if (TimeCount <= 0)
        {
            //GameOver
            Destroy(gameObject);
        }

    }
}
