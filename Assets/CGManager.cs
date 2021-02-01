using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CGManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (videoPlayer.isPaused == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }

        
    }
}
