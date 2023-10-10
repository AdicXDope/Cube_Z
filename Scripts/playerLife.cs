using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerLife : MonoBehaviour
{
    public AudioSource dieSound;
    bool dead = false;
    public GameObject player;

    private void Update()
    {
        if(transform.position.y< -2f && !dead)
        {
            Invoke("Die",1f);
            Invoke("ReloadLevel",1f);
            DieSound();
            dead = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy body"))
        {
            
            GetComponent<Rigidbody>().isKinematic= true;
            GetComponent<Player_movements>().enabled = false;
            Invoke("Die",1f);
            Invoke("ReloadLevel",1f);
            DieSound();

        }
    if(collision.gameObject.CompareTag("obstacles"))
    {
        GetComponent<Player_movements>().enabled = false;
        Invoke("Die",1f);
        Invoke("ReloadLevel",1f);
        DieSound();
    
     }
    }

    //  private void OnCollisionEnter(Collision CollisionInfo)
    // {
    //     if(CollisionINfo.collider.tag == "obstacles")
    // {
    //     GetComponent<Player_movements>().enabled = false;
    //     Die();
    
    // }
        
        
    // }
    void Die()
    {
       
        Invoke(nameof(ReloadLevel),1.3f);
        dead = true;
        
        Destroy(player);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void DieSound()
    {
        dieSound.Play();
    }
}
