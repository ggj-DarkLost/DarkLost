using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    public Transform transMove;
    
    Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(transMove!=null)
            position = transMove.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transMove != null)
        {
            float disX = transMove.localPosition.x - position.x;
            moveAnim(disX);
        }
    }
    void moveAnim(float dis)
    {
        anim.SetFloat("dis", dis);
        SoundManager.instance.EnemyAudio();
    }
}
