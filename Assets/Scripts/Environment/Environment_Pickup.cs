using UnityEngine;
using System.Collections;

public class Environment_Pickup : MonoBehaviour {

    public bool isShard;

    public Transform textField;
    
    // Use this for initialization
	void Start () {
        textField.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //textField.gameObject.SetActive(false);
	}

    void OnTriggerEnter ( Collider col)
    {
        if (col.tag == "Player")
        {
            if (isShard)
            {
                //destroy this
                //do GUI stuff
                Destroy(this);
            }
            
            else
            {
                //don't destroy this
                //turn on GUI text
                textField.gameObject.SetActive(true);
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
            }
        }
    }
}
