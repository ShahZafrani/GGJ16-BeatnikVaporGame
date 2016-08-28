using UnityEngine;
using System.Collections;

public class System_EndGame : MonoBehaviour {

    public bool doThis;

    public System_Fade systemFade;

    public Transform finalQuote;

    public GAME_STATE states;
    public enum GAME_STATE
    {
        PLAY = 0,
        TRIGGERED = 1,
        COMPLETE = 2
    }

    // Use this for initialization
    void Start () {
        finalQuote.gameObject.SetActive(false);
        doThis = false;
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
	    if (systemFade.states == System_Fade.SMUDGE_STATE.VISIBLE)
        {
            states = GAME_STATE.TRIGGERED;
        }
	}

    IEnumerator PLAY()
    {
        yield return new WaitForSeconds(0);
    }

    IEnumerator TRIGGERED()
    {
        yield return new WaitForSeconds(1.5f);
        finalQuote.gameObject.SetActive(true);
        states = GAME_STATE.COMPLETE;
    }

    IEnumerator COMPLETE()
    {
        yield return new WaitForSeconds(0);
    }
}
