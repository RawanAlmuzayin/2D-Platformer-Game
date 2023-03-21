using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerDeath : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

  
    private void OnCollisionEnter2D( Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            anim.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
