using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float upForce = 200f;

    Rigidbody2D rb2d;
    
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
            return;
        
        // Jump Player
        if (Input.GetMouseButtonDown(0))
        {
            // Reset the velocity to zero
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
    }

}
