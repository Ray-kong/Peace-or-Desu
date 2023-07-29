using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;


    public GameObject Idle;
    public GameObject Swalk;
    public GameObject Bwalk;
    public GameObject Rwalk;
    public GameObject Lwalk;
    private bool check;
    
    public 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        Idle.SetActive(true);
        Swalk.SetActive(false);
        Bwalk.SetActive(false);
        Rwalk.SetActive(false);
        Lwalk.SetActive(false);

        
    }

    void Update()
    {
        Movement();
       
        MoveAnim();

        void Movement()
        {
            // Get input from the keyboard
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            movement = new Vector2(moveX, moveY);

            rb.velocity = movement * speed;

        }
        void MoveAnim()
        {

           if (Input.GetKey(KeyCode.UpArrow))
            {
                Idle.SetActive(false);
                Swalk.SetActive(false);
                Bwalk.SetActive(true);
                Rwalk.SetActive(false);
                Lwalk.SetActive(false);
            }

           else if (Input.GetKey(KeyCode.DownArrow))
            {
                Idle.SetActive(false);
                Swalk.SetActive(true);
                Bwalk.SetActive(false);
                Rwalk.SetActive(false);
                Lwalk.SetActive(false);
            }

           else if (Input.GetKey(KeyCode.RightArrow))
            {
                Idle.SetActive(false);
                Swalk.SetActive(false);
                Bwalk.SetActive(false);
                Rwalk.SetActive(true);
                Lwalk.SetActive(false);
            }

          else  if (Input.GetKey(KeyCode.LeftArrow))
            {
                Idle.SetActive(false);
                Swalk.SetActive(false);
                Bwalk.SetActive(false);
                Rwalk.SetActive(false);
                Lwalk.SetActive(true);
                
            }

            else {
                Idle.SetActive(true);
                Swalk.SetActive(false);
                Bwalk.SetActive(false);
                Rwalk.SetActive(false);
                Lwalk.SetActive(false);
            }






        }
    }

}