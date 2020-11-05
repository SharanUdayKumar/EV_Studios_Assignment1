
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_control : MonoBehaviour

{

    public Rigidbody2D rb;
    [SerializeField]
    public float jump_force;
    public float raycastdist;
    public bool isgrounded;
    public LayerMask groundlayers;
    public bool move;
    public Transform ball_downside;
    public float speed =500f;
    Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        isgrounded = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
        PlayerMove();

    }

    private void PlayerMove()
    {
        Collider2D groundcheck = Physics2D.OverlapCircle(ball_downside.position, 0.005f, groundlayers);
        if (groundcheck != null)
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }

        Vector3 objectraypos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//, 

        Vector2 objectraypos2D = new Vector2(objectraypos.x, objectraypos.y);

        RaycastHit2D objectray = Physics2D.Raycast(objectraypos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && isgrounded)
        {

            //isgrounded = false;
            LeftorRightMovement();
            if (objectray.collider != null)//&& isgrounded && Input.GetMouseButtonDown(0))
            {
                Debug.Log("youclickedongo");
                rb.velocity = new Vector2(0f, jump_force);

            }


        }


        // Ray moveray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (move == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        }

        // if(isgrounded == false)

    }

    private void LeftorRightMovement()
    {
        targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        targetpos.y = transform.position.y;
        targetpos.z = transform.position.z;

        if(move ==false)
        {
            move = true;
        }

     
        //RaycastHit2D hit;

       // if (Physics.Raycast(ray, out hit, 1000))
        

    }
}
