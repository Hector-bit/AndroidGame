using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Level1 is the mars level
//Level2 is the planet1 llevel
//Level3 is the moon level

public class Victory : Stats
{
    // public playerBadgeCase = Stats.planetBadges;
    private string[] planetBadgesAvailable = {"marsBadge", "planetOneBadge", "moonBadge"};
    private string[] levelNames = {"Level1", "Level2", "Level3"};
    public string badgeToBeEarned = "empty";
    // private string[] pass = planetBadges;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); 
        for(int i = 0; i < levelNames.Length; i ++){
            if(levelNames[i] == currentScene.name){
                badgeToBeEarned = planetBadgesAvailable[i];
            }
            // Debug.Log("We are on level: " + levelNames[i] + " and this is the badge " + badgeToBeEarned);
        }
    }

    void ReachedTheSpaceship()
    {
        //once the player reaches the spaceship a couple things will happen
        //first they will earn a badge for the current level
        planetBadges.Add(badgeToBeEarned);
        //second a victory canvas will appear

    }
} 