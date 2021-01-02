using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player dies then respawns with this script

public class Death : Stats
{
   private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("DeathZone")) {
            Destroy(gameObject);
            Stats.instance.Respawn();
        }
    }
}
