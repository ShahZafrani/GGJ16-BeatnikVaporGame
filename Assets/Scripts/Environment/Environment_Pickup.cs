using UnityEngine;
using System.Collections;

public class Environment_Pickup : MonoBehaviour {

    public bool isHit;

    public float waitTime;

    //public Transform textBackground;
    public Transform textField;

    public System_Record systemRecord;
    
    // Use this for initialization
	void Start () {
        isHit = false;

        textField.gameObject.SetActive(false);
        //textBackground.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter ( Collider col)
    {
        if (col.tag == "Player" && !isHit)
        {
            textField.gameObject.SetActive(true);
            //textBackground.gameObject.SetActive(true);
            Destroy(transform.Find("Particle System").gameObject);
            StartCoroutine(TextDelay(waitTime));
        }
    }

    //void OnTriggerExit(Collider col)
    //{
    //    if (col.tag == "Player")
    //    {
    //        Destroy(transform.Find("Particle System").gameObject);
    //    }
    //}

    IEnumerator TextDelay (float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //fade objects
        textField.gameObject.SetActive(false);
        isHit = true;
        //textBackground.gameObject.SetActive(false);
    }
}
