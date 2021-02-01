using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogsManager : MonoBehaviour
{
    public static int DogNumber;
    public int dogNumber;

    private void Start()
    {
        DogsManager.DogNumber = dogNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (DogNumber == 0)
        {
            //Win
            SceneManager.LoadScene("EndScene");
        }
    }
}
