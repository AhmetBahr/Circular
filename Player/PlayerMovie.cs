using UnityEngine;



public class PlayerMovie : MonoBehaviour
{
    float timeCounter = 0;
    public float speed = 2.5f;
    float width = 1.5f;
    float height = 1.5f;
    int yon = 1;
    int can;
    int gems;


    public int Score;

    ManuScript referanskod2;


    bool isDeath;

    void Start()
    {
        referanskod2 = GameObject.Find("Manager").GetComponent<ManuScript>();
        Score = 0;
        can = 2;
    }


    void Update()
    {
       

        if (yon == 1)
            timeCounter += Time.deltaTime * speed;

        if (yon == -1)
            timeCounter += Time.deltaTime * speed * -1;


        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = -3;

        transform.position = new Vector3((13 * x) / 20, (13 * y) / 20, z);

    }
    public void Tap()
    {
        yon *= -1;
        PlayerSount.PlayerSound("swing");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Point")
        {
            SkorUp();
            PlayerSount.PlayerSound("point");
         
        }
        if (collision.transform.tag == "Point2")
        {
            SkorUp2();
            PlayerSount.PlayerSound("point");

        }


        if (collision.transform.tag == "Enemy")
        {
            deat();
            PlayerSount.PlayerSound("expoo");
        }
    }

    

    public void deat()
    {
        referanskod2.death();
        Destroy(gameObject);
            
       
    }


    public void SkorUp()
    {
        Score++;
        referanskod2.scoreUp();
    }

    public void SkorUp2()
    {
        Score += 2;
        referanskod2.scoreUp2();
    }
}
