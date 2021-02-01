using UnityEngine;
using UnityEngine.Video;

public class MyVideo : MonoBehaviour
{
    public VideoPlayer vPlayer;

    void Start()
    {
        vPlayer.loopPointReached += EndReached;
        vPlayer.Play();
    }

    void EndReached(VideoPlayer vPlayer)
    {
        Debug.Log("End reached!");
    }

    void Update()
    {
        Debug.Log("Frame " + vPlayer.frame);
    }
}
