﻿using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public GAME_STATE states;
    public enum GAME_STATE
    {
        PLAY = 0,
        INTERACT = 1,
        WAIT = 2
    }

    public float speed;
    public float waitTime;
    public float interactTime;

    public System_Record systemRecord;

    // Use this for initialization
    void Start () {
        StartCoroutine(CreateFSM());
    }

    IEnumerator CreateFSM()
    {
        while (true)
        {
            yield return StartCoroutine(states.ToString());
        }
    }

    // Update is called once per frame
    void Update () {
        if (systemRecord.shardNum == 7)
        {
            states = GAME_STATE.INTERACT;
        }
    }

    IEnumerator PLAY()
    {
        yield return new WaitForSeconds(0);
        //do movement logic here
        //just use ifs. smoother movement
        Vector3 movement = new Vector3();

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            //moveStates = MOVE_STATE.UP;
            movement.z += speed;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            //moveStates = MOVE_STATE.DOWN;
            movement.z -= speed;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //moveStates = MOVE_STATE.LEFT;
            movement.x -= speed;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //moveStates = MOVE_STATE.RIGHT;
            movement.x += speed;
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            //moveStates = MOVE_STATE.IDLE;
            movement = new Vector3(0, 0, 0);
        }

        transform.position += movement * Time.deltaTime;
    }

    IEnumerator INTERACT()
    {
        yield return new WaitForSeconds(0);
    }

    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(waitTime);
        states = GAME_STATE.PLAY;
    }
}
