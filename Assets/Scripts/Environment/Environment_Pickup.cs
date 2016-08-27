using UnityEngine;
using System.Collections;

public class Environment_Pickup : MonoBehaviour {

    public bool isHit;

    public float waitTime;

    public Transform textBackground;
    public Transform textField;

    public System_Record systemRecord;
    
    // Use this for initialization
	void Start () {
        isHit = false;

        textField.gameObject.SetActive(false);
        textBackground.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter ( Collider col)
    {
        if (col.tag == "Player")
        {
            isHit = true;
            textField.gameObject.SetActive(true);
            textBackground.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            //if leave trigger
            //fade guitext then destroy object (use coroutine)
            StartCoroutine(TextDelay(waitTime));
        }
    }

    IEnumerator TextDelay (float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //fade objects
        textField.gameObject.SetActive(false);
        textBackground.gameObject.SetActive(false);
    }
}
