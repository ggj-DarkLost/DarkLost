using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDirection;
    bool isLightOpen;
    public Light2D torchLight;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torchLight.gameObject.SetActive(false);
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
            TorchRotation1();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");
        if (moveX != 0 || moveY != 0) { 
            direction = new Vector3(moveX, moveY, 0);
        }
        moveDirection = new Vector2(moveX, moveY).normalized;

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
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

    void TorchRotation1()
    {
        torchLight.gameObject.transform.up = direction;
    }
}
