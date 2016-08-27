using UnityEngine;
using System.Collections;

public class System_Fade : MonoBehaviour {

    public GameObject Sprite;///the sprite (most of the time most of the people use plane for sprite)
    public float fadespeed = 2;
    public GUITexture Spriteb;//if u are using this for sprite

    void Update()
    {
        ////if hit with particles
        //if (Sprite)
        //{
        //    Sprite.GetComponent<Renderer>().material.color.a = Mathf.Lerp(Sprite.GetComponent<Renderer>().material.color.a, 0, Time.deltaTime * fadespeed);
        //    if (Sprite.GetComponent<Renderer>().material.color.a == 0)
        //    {
        //        FadeIn();
        //    }
        //}
        //if (Spriteb)
        //{
        //    Spriteb.color.a = Mathf.Lerp(Spriteb.color.a, 0, Time.deltaTime * fadespeed);
        //    if (Spriteb.color.a == 0)
        //    {
        //        FadeIn();
        //    }
        //}
    }

    //IEnumerator FadeIn()
    //{
    //    //yield return new WaitForSeconds(2);
    //    //if (Spriteb)
    //    //{
    //    //    Spriteb.color.a = Mathf.Lerp(Spriteb.color.a, 1, Time.deltaTime * fadespeed);
    //    //}
    //    ////if hit with particles
    //    //if (Sprite)
    //    //{
    //    //    Sprite.GetComponent<Renderer>().material.color.a = Mathf.Lerp(Sprite.GetComponent<Renderer>().material.color.a, 1, Time.deltaTime * fadespeed);
    //    //}
    //}
}
