using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("移动参数")]
    public float moveSpeed;
    Vector2 moveDirection;
    float moveX, moveY, animMoveX, animMoveY;
    bool isMove = false;

    [Header("灯光参数")]
    public Light2D torchLight;
    bool isLightOpen;
    Vector3 direction;
    //bool outFlag = false;

    [Header("动画参数")]
    private int idleX, idleY, walkX, walkY,isDeath,isOut;
    Animator anim;

    public string playerCondition;
    //PlayerConditions: default, UnderSpot, Vanishing
    public float TimeCountSet;
    public float TimeCount;
    [Space]
    public GameObject PlayerActiveCollider;

    [Header("动画参数")]
    public AudioSource walkAudio;
    public AudioSource openTorchAudio;
    public AudioSource stuckAudio;
    public AudioSource outAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torchLight.gameObject.SetActive(false);
        anim = GetComponent<Animator>();

        idleX = Animator.StringToHash("X");
        idleY = Animator.StringToHash("Y");
        walkX = Animator.StringToHash("walkX");
        walkY = Animator.StringToHash("walkY");
        isDeath = Animator.StringToHash("isDeath");
        isOut = Animator.StringToHash("isOut");

        playerCondition = "default";
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        TorchLightChange();
        anim.SetFloat(idleX, Input.GetAxis("Horizontal"));
        anim.SetFloat(idleY, Input.GetAxis("Vertical"));
        anim.SetFloat(walkX, Input.GetAxis("Horizontal"));
        anim.SetFloat(walkY, Input.GetAxis("Vertical"));

        PlayerCondition();
    }

    private void FixedUpdate()
    {
        Move();
        if (isLightOpen)
        {
            //TorchRotation();
            TorchRotation();
        }
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        animMoveX = Input.GetAxisRaw("Horizontal");
        animMoveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            direction = new Vector3(moveX, moveY, 0);
        }
        moveDirection = new Vector2(moveX, moveY).normalized;

    }
    void Move()
    {
        if (playerCondition == "default")
        {
            
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            walkAudio.Play();
        }
        anim.SetFloat("SpeedX", Mathf.Abs(animMoveX));
        anim.SetFloat("SpeedY", Mathf.Abs(animMoveY));

        FaceDirection();

    }
    void TorchLightChange()
    {
        if (isLightOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                openTorchAudio.Play();
                torchLight.gameObject.SetActive(false);
                isLightOpen = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                openTorchAudio.Play();
                torchLight.gameObject.SetActive(true);
                torchLight.gameObject.transform.up = direction;
                isLightOpen = true;
            }
        }
    }

    //光随鼠标变

    //void TorchRotation()
    //{
    //    Vector3 mouse = Input.mousePosition;
    //    Vector3 torch = Camera.main.WorldToScreenPoint(transform.position);
    //    Vector3 direction = mouse - torch;
    //    direction.z = 0f;
    //    direction = direction.normalized;
    //    transform.up = direction;
    //}

    void TorchRotation()
    {
        torchLight.gameObject.transform.up = direction;
    }

    void FaceDirection()
    {
        if (moveX < 0)
            transform.localScale = new Vector2(6, 6);
        if (moveX > 0)
            transform.localScale = new Vector2(-6, 6);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDetector")
        {
            playerCondition = "UnderSpot";
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDetector")
        {
            playerCondition = "default";
        }
    }
    public void PlayerCondition()
    {
        if (playerCondition == "UnderSpot")
        {
            TimeCount -= Time.deltaTime;
            if (PlayerActiveCollider.activeInHierarchy == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //SoundManager.instance.ReflectAudio();
                    PlayerActiveCollider.SetActive(true);
                    stuckAudio.Play();
                }
            }

            if (TimeCount <= 0)
            {
                anim.SetTrigger(isDeath);
                //Death();
            }
        }
        else
        {
            
            TimeCount = TimeCountSet;
            PlayerActiveCollider.SetActive(false);
            outAudio.Play();
            
        }

        if (TimeCount <= 0)
        {
            //SoundManager.instance.
            anim.SetTrigger(isDeath);
            
        }
    }
    public void Death()
    {
        //GameOver
        //Destroy(gameObject);
        //回到出生点
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void renewCondition()
    {
        anim.SetBool(isOut, false);
    }
}