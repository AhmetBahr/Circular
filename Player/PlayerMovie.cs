using System.Collections;
using UnityEngine;



public class PlayerMovie : MonoBehaviour
{

    [Header("Core")]
    [SerializeField] private float speed = 2.5f;
     private float timeCounter = 0;
     private float width = 1.2f;
     private float height = 1.2f;
     private int yon = 1;

    [Header("Health")]
    [SerializeField] public int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private bool touchable;
    [SerializeField] private float cantouchTime;

   [SerializeField] public int Score;

    ManuScript referanskod2;
    Tail tail;

    void Start()
    {
        referanskod2 = GameObject.Find("Manager").GetComponent<ManuScript>();
        tail = GameObject.Find("Tail").GetComponent<Tail>();

        Score = 0;

    }


    void Update()
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
            tail.scoreForheard = 0;
        }

        if (yon == 1)
            timeCounter += Time.deltaTime * speed;

        if (yon == -1)
            timeCounter += Time.deltaTime * speed * -1;


        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = -3;

        transform.position = new Vector2( x, y );

        if(touchable == false) 
        {
            cantouchTime -= Time.deltaTime; 
        }
        if(cantouchTime >= 0) 
        {
            touchable = true;
        }


        if (Time.frameCount % 3 == 0)
            heartSystem();
    }
    public void Tap()
    {
        yon *= -1;
        PlayerSount.PlayerSound("swing");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (touchable)
        {
            if (collision.CompareTag("Point"))
            {
                SkorUp();
                PlayerSount.PlayerSound("point");

            }
        }


        if (touchable)
        {
            if (collision.CompareTag("Enemy"))
            {
                deat();
                touchable = false;
                cantouchTime = 0.5f;
                PlayerSount.PlayerSound("expoo");
            }
        }
    }

    

    public void deat()
    {
        if(health <= 0)
        {
            referanskod2.death();
            gameObject.SetActive(false);
            
        }

        health--;
        tail.scoreForheard = 0;

        tail.TailRemove();

    }

    public void Reborn()
    {
        referanskod2.Rebornscrean();
        gameObject.SetActive(true);
        TakeShield();
        //recounter anim 
        Time.timeScale = 0.5f;

        StartCoroutine(Restarttr());     

    }

    private void heartSystem()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(false);
        }
        for(int i = 0;i < health; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    public void TakeShield()
    {

        health++;

    }
    

    public void SkorUp()
    {
        Score++;
        referanskod2.scoreUp();
    }





    private IEnumerator Restarttr()
    {
        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 1f;



    }

}
