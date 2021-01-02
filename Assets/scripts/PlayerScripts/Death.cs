using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player dies then respawns with this script

public class Death : MonoBehaviour
{
   public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
            stats.instance.Respawn();
        }
    }
}
