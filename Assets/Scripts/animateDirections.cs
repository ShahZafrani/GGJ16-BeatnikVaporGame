using UnityEngine;
using System.Collections;

public class animateDirections : MonoBehaviour
{
	private Animator anim;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");

		if (lastInputX != 0 || lastInputY != 0) {
			anim.SetBool ("Walking", true);

			if (lastInputX > 0)
            {
				anim.SetInteger ("Direction", 4);
                Debug.Log("right");
			}

            if (lastInputX < 0)
            {
				anim.SetInteger("Direction", 3);
                Debug.Log("left");
            } 

			if (lastInputY > 0)
            {
				anim.SetInteger ("Direction", 1);
                Debug.Log("up");
            }

            if (lastInputY < 0)
            {
				anim.SetInteger("Direction", 2);
                Debug.Log("down");
            } 

		}

        else
        {
			anim.SetBool ("Walking", false);
            Debug.Log("idle");
        }
	}
}

