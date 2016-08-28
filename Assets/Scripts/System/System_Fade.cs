using UnityEngine;
using System.Collections;

public class System_Fade : MonoBehaviour {

    public float fadeTime;

    public System_Record systemRecord;

    SpriteRenderer sRend;
    Color defaultColor;

    public SMUDGE_STATE states;
    public enum SMUDGE_STATE
    {
        WAIT = 0,
        VISIBLE = 1,
        FADEOUT = 2
    }

    // Use this for initialization
    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        defaultColor = sRend.material.color;

        states = SMUDGE_STATE.WAIT;
        StartCoroutine(CreateFSM());
    }

    // Update is called once per frame
    void Update()
    {
        if (systemRecord.shardNum >= 6)
        {
            states = SMUDGE_STATE.VISIBLE;
        }
        else
            states = SMUDGE_STATE.WAIT;
    }

    IEnumerator CreateFSM()
    {
        while (true)
        {
            yield return StartCoroutine(states.ToString());
        }
    }

    IEnumerator WAIT()
    {
        defaultColor.a = 0.0f;
        sRend.material.color = defaultColor;
        yield return new WaitForSeconds(0);
    }

    IEnumerator VISIBLE()
    {
        FadeIn();
        yield return new WaitForSeconds(0);
    }

    IEnumerator FADEOUT()
    {
        FadeOut();
        yield return new WaitForSeconds(0);
    }

    void FadeIn()
    {
        defaultColor.a += Time.deltaTime / fadeTime;
        sRend.material.color = defaultColor;
    }

    void FadeOut()
    {
        defaultColor.a -= Time.deltaTime;
        sRend.material.color = defaultColor;
    }
}
