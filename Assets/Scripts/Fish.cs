using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour


   
{

    [SerializeField]
    private float _speed;
    int angel;
    int maxAngel = 20;
    int minAngel=-60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    

    Rigidbody2D _rbdy;
    // Start is called before the first frame update
    void Start()
    {
        
        _rbdy = GetComponent<Rigidbody2D>();
        _rbdy.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Tap_toSwim();

        




    }

    private void FixedUpdate()
    {
        Rotation();
    }


    void Tap_toSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver==false)
        {
            if (GameManager.gameStarted==false)
            {
                _rbdy.gravityScale = 4f;
                _rbdy.velocity = Vector2.zero;
                _rbdy.velocity = new Vector2(_rbdy.velocity.x, _speed);
                gameManager.GameHasStarted();
            }
            else
            {
                _rbdy.velocity = Vector2.zero;
                _rbdy.velocity = new Vector2(_rbdy.velocity.x, _speed);
            }
            

        }
    }

    void Rotation()
    {

        if (_rbdy.velocity.y > 0)
        {

            if (angel <= maxAngel)
            {
                angel = angel + 4;

            }
        }


        else if (_rbdy.velocity.y < 0)
        {
            if (angel >= minAngel)
            {
                angel = angel - 1;

            }
        }

        if (touchedGround==false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }

        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {

            // Debug.Log("Scored..");

            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            gameManager.GameOver();
            


        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver==false)
            {
                gameManager.GameOver();
            }
            else
            {
                GameOver();
            }
        }
        

    }
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);

        sp.sprite = fishDied;
        anim.enabled = false;
    }



}
