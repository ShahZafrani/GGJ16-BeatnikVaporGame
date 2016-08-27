using UnityEngine;
using System.Collections;

public class System_Record : MonoBehaviour {

    public int shardNum;

    public float eventTime;

    public Transform shard_0;
    public Transform shard_1;
    public Transform shard_2;
    public Transform shard_3;
    public Transform shard_4;
    public Transform shard_5;

    // Use this for initialization
    void Start () {
        shardNum = 0;

        shard_0.gameObject.SetActive(false);
        shard_1.gameObject.SetActive(false);
        shard_2.gameObject.SetActive(false);
        shard_3.gameObject.SetActive(false);
        shard_4.gameObject.SetActive(false);
        shard_5.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        switch (shardNum)
        {
            case 0:
                shard_0.gameObject.SetActive(false);
                shard_1.gameObject.SetActive(false);
                shard_2.gameObject.SetActive(false);
                shard_3.gameObject.SetActive(false);
                shard_4.gameObject.SetActive(false);
                shard_5.gameObject.SetActive(false);
                break;
            case 1:
                shard_0.gameObject.SetActive(true);
                break;
            case 2:
                shard_1.gameObject.SetActive(true);
                break;
            case 3:
                shard_2.gameObject.SetActive(true);
                break;
            case 4:
                shard_3.gameObject.SetActive(true);
                break;
            case 5:
                shard_4.gameObject.SetActive(true);
                break;
            case 6:
                shard_5.gameObject.SetActive(true);
                StartCoroutine(Increment());
                break;
            case 7:
                //turn off record pieces
                shard_0.gameObject.SetActive(false);
                shard_1.gameObject.SetActive(false);
                shard_2.gameObject.SetActive(false);
                shard_3.gameObject.SetActive(false);
                shard_4.gameObject.SetActive(false);
                shard_5.gameObject.SetActive(false);
                break;
        }
	}

    IEnumerator Increment ()
    {
        yield return new WaitForSeconds(eventTime);
        shardNum = 7;
    }

    //IEnumerator Fade (Transform target)
    //{
    //    for (float f = 1f; f >= 0; f -= 0.1f)
    //    {
    //        Color c = target.GetComponent<Renderer>().material.color;
    //        c.a = f;
    //        target.GetComponent<Renderer>().material.color = c;
    //        yield return null;
    //    }

    //    shardFull.gameObject.SetActive(true);
    //    yield return null;
    //}
}
