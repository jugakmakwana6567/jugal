using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletshoot : MonoBehaviour
{


    Rigidbody2D rb;
    Vector3 lastVelocity;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }   

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        print("OnCollisionEnter2D");
        var reflect = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        var angle = Mathf.Atan2(reflect.y, reflect.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        rb.velocity = reflect * lastVelocity.magnitude;

        count++;
        
        //rb.freezeRotation = true;
        if(count==8)
        {
            Destroy(gameObject);
           
        }
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       // print("" + collision.tag);

            var enemy = collision.gameObject;
            Animator animator = enemy.GetComponent<Animator>();
            animator.SetTrigger("T");
           Destroy(enemy, 2f);
        // enemykill.ek.youwinmethod();
        enemykill.ek.gameovr();
          


    }



}
