using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("移动参数")]
    public float moveSpeed;
    Vector2 moveDirection;
    float moveX, moveY;

    [Header("灯光参数")]
    public Light2D torchLight;
    bool isLightOpen;
    Vector3 direction;
    
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torchLight.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        TorchLightChange();
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
        if (moveX != 0 || moveY != 0) { 
            direction = new Vector3(moveX, moveY, 0);
        }
        moveDirection = new Vector2(moveX, moveY).normalized;

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        FaceDirection();
    }
    void TorchLightChange()
    {
        if (isLightOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                torchLight.gameObject.SetActive(false);
                isLightOpen = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
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
            transform.localScale = new Vector2(-1, 1);
        if (moveX > 0)
            transform.localScale = new Vector2(1, 1);
        if (moveY < 0)
            transform.localScale = new Vector2(-1, 1);
        if (moveY > 0)
            transform.localScale = new Vector2(1, 1);
    }
}
