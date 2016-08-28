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
	void FixedUpdate ()
	{
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");

		if (lastInputX != 0 || lastInputY != 0) {
			anim.SetBool ("Walking", true);

			if (lastInputX > 0) {
				anim.SetInteger ("Direction", 4);
			} else if (lastInputX < 0) {
				anim.SetFloat ("Direction", 3);
			} 

			if (lastInputY > 0) {
				anim.SetInteger ("Direction", 1);
			} else if (lastInputY < 0) {
				anim.SetFloat ("Direction", 2);
			} 

		} else {
			anim.SetBool ("Walking", false);
		}
	}
}

