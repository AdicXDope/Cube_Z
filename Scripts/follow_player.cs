
using UnityEngine;

public class follow_player : MonoBehaviour
{
    // Start is called before the first frame update
   
   public Transform player;
   public Vector3 offset;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}
