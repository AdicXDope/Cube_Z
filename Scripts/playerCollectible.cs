using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerCollectible : MonoBehaviour
{
  public AudioSource coinSound;
  int Coins = 0;
  [SerializeField] TextMeshProUGUI coinstext;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("coins"))
    {
    Destroy(other.gameObject);
    Coins++;
    coinstext.text= "Coins = " + Coins;
    coinSound.Play();

    }

  }

//    private void OnCollisionEnter(Collision collision)
//     {
//         if(collision.gameObject.CompareTag("coins"))
//         {
//             Destroy(collision.transform.gameObject);
//             Coins++;
//             Debug.Log("Coins = " + Coins);
//         }
//     }
}

