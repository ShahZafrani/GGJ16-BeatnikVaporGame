using UnityEngine;
using System.Collections;

public class Environment_Trigger : MonoBehaviour {

    public bool isComplete;

    public Collider[] colliders;
    public Collider[] props;

    public Shader newShader;

    public int colCheck;

    public System_Record systemRecord;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (colCheck == colliders.Length)
        {
            isComplete = true;
        }

        if (colCheck >= colliders.Length)
            colCheck = colliders.Length;
	}

    void OnTriggerStay (Collider col)
    {
        if (col.tag == "Player")
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<Environment_Pickup>().isHit == true)
                {
                    colCheck++;
                    Debug.Log("all hit");
                    //isWaiting = false;
                }
                else
                    colCheck = 0;
            }

            foreach (Collider prps in props)
            {
                if (isComplete)
                {
                    //change shaders
                    prps.GetComponent<Renderer>().material.shader = newShader;
                    systemRecord.shardNum++;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
