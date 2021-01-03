using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject character;
    public GameObject respawn;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            character.transform.position = new Vector3(4,7,0);
        }
    }
}
