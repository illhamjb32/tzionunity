using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
    {
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        float horizontalinput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space)&&Grounded)
            Jump();
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("ground", Grounded); 
        if (horizontalinput > 0.01f)
            transform.localScale = new Vector3(1,1,1);
      else  if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
    }
        private void Jump()
        {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        Grounded = false;
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            Grounded = true;
    }
    public bool canAttack()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        return horizontalinput == 0 && Grounded;
    }
}


   
