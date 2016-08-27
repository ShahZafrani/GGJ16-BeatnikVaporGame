using UnityEngine;
using System.Collections;

public class Environment_Pickup : MonoBehaviour {

    public bool isShard;
    public bool isHit;

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
            if (isShard)
            {
                //destroy this
                //do GUI stuff
                systemRecord.shardNum++;
                Destroy(this.gameObject);
            }
            
            else
            {
                //don't destroy this
                //turn on GUI text
                isHit = true;
                textField.gameObject.SetActive(true);
                textBackground.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!isShard)
            {
                //if leave trigger, disable GUI text
                textField.gameObject.SetActive(false);
                textBackground.gameObject.SetActive(false);
            }
        }
    }
}
