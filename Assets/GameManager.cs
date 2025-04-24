using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        STARTMENU,
        PLAYING,
        GAMEOVER,
        PAUSE
    }
    public GameState gameStateMachine;


    bool managerExists = false;

    void Awake()
    {
        //first we find an array of ALL gameObjects in the scene that are GameManagers
        GameObject[] mgrs = GameObject.FindGameObjectsWithTag("GameManager");

        //then we check each individual GameManager against the one THIS script is on
        foreach(GameObject mgr in mgrs)
        {
            //if the LOCAL exists variable == false then we check the other objects, if they are TRUE, then we blow up this object
            if(!managerExists && mgr.GetComponent<GameManager>().managerExists)
            {
                Destroy(this.gameObject);
            }
        }
        managerExists = true;
        gameStateMachine = GameState.PAUSE;
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        switch(gameStateMachine)
        {
            case GameState.PAUSE:
            //logic that runs when the game is paused goes here
            Time.timeScale = 0f;
            break;

            case GameState.STARTMENU:
            //start menu only
            break;

            case GameState.GAMEOVER:
            //when you lose
            break;

            case GameState.PLAYING:
            //game is playing
            break;


        }

        
    }

    void changeState(GameState target)
    {
        gameStateMachine = target;
    }
}