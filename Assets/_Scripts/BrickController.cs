﻿using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int maxHits;
    public int timesHit;

    private LevelManagerController levelManager;

    // Use this for initialization
    void Start ()
    {
        levelManager = FindObjectOfType<LevelManagerController>();
        if (IsBreakable())
        {
            levelManager.brickCount++;
        }
        timesHit = 0;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsBreakable() && (++timesHit >= maxHits))
        {
            Destroy(this.gameObject);
            levelManager.brickCount--;
        }
        //SimulateWin();
    }

    bool IsBreakable()
    {
        return gameObject.tag.Equals("Breakable");
    }

    // TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
