using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Level1 is the mars level
//Level2 is the planet1 llevel
//Level3 is the moon level

public class Stats : MonoBehaviour
{
    //Everything that is commented out was used for a different type of respawn
    //method that I tried and may or may not try to use again.

    
    // public static Stats instance;
    // public string[] planetBadges = new string[] {"moonBadge", "marsBadge", "planetOneBadge"};
    public List<string> planetBadges = new List<string>();

    void Awake(){
        planetBadges.Add("moonBadge");
    }
    // public Transform respawnPoint;
    // public GameObject playerPrefab;

    // public CinemachineVirtualCameraBase cam;

    // private void Awake() {
    //     instance = this;
    // }

    // public void Respawn () {
    //     GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    //     cam.Follow = player.transform;
    // }
}
