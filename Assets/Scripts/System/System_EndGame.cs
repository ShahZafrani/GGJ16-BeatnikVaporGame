using UnityEngine;
using System.Collections;

public class System_EndGame : MonoBehaviour {

    public System_Fade systemFade;

    public Transform finalQuote;

	// Use this for initialization
	void Start () {
        finalQuote.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (systemFade.states == System_Fade.SMUDGE_STATE.VISIBLE)
        {
            finalQuote.gameObject.SetActive(true);
        }
	}
}
