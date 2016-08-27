using UnityEngine;
using System.Collections;

public class Environment_Trigger : MonoBehaviour {

    public bool isComplete;

    public Collider[] colliders;
    public Collider[] props;

    public float textTime;
    public Transform finalQuote;

    public Shader oldShader;
    public Shader newShader;

    public int colCheck;

    public System_Record systemRecord;

    public GAME_STATE states;
    public enum GAME_STATE
    {
        PLAY = 0,
        TRIGGERED = 1,
        COMPLETE = 2
    }

    GameObject player;

    // Use this for initialization
    void Start () {
        finalQuote.gameObject.SetActive(false);
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
        if (states != GAME_STATE.COMPLETE)
        {
            if (colCheck == colliders.Length)
            {
                isComplete = true;
            }

            if (colCheck >= colliders.Length)
                colCheck = colliders.Length;

            if (isComplete)
                states = GAME_STATE.TRIGGERED;
        }          
    }

    void OnTriggerStay (Collider col)
    {
        if (col.tag == "Player")
        {
            if (states == GAME_STATE.PLAY)
            {
                player = col.gameObject;
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].GetComponent<Environment_Pickup>().isHit == true)
                    {
                        colCheck++;
                    }
                    else
                        colCheck = 0;
                }
            }

            else if (states == GAME_STATE.COMPLETE)
            {
                foreach (Collider prps in props)
                {
                    //if (isComplete)
                    //{
                        //change shaders
                        prps.GetComponent<Renderer>().material.shader = newShader;
                        //systemRecord.shardNum++;
                    //}
                }

                col.GetComponent<Renderer>().material.shader = newShader;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player" && states == GAME_STATE.COMPLETE)
        {
            col.GetComponent<Renderer>().material.shader = oldShader;
        }
    }

    IEnumerator PLAY()
    {
        yield return new WaitForSeconds(0);
    }

    IEnumerator TRIGGERED()
    {
        player.GetComponent<Player_Movement>().states = Player_Movement.GAME_STATE.INTERACT;
        //zoom in
        //fade in black
        yield return new WaitForSeconds(2.0f);
        //display quote
        finalQuote.gameObject.SetActive(true);
        //fade black out
        //zoom out
        yield return new WaitForSeconds(textTime);
        player.GetComponent<Player_Movement>().states = Player_Movement.GAME_STATE.PLAY;
        //remove quote
        finalQuote.gameObject.SetActive(false);
        systemRecord.shardNum++;
        states = GAME_STATE.COMPLETE;
    }

    IEnumerator COMPLETE()
    {
        yield return new WaitForSeconds(0);
    }
}
