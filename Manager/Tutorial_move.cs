using UnityEngine;

public class Tutorial_move : MonoBehaviour
{
    private float speed = 1.1f;
    [SerializeField] private Rigidbody2D rb;


    public void Movestart()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);

        Destroy(gameObject, 10);

    }


   

    
   
}
