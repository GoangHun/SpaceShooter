using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public Transform bg1;
    public Transform bg2;

    private Bounds bgBounds;

    private void Awake()
    {
        bgBounds = bg1.gameObject.GetComponent<Renderer>().bounds;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var target = collision.transform;
        if (target == bg1 || target == bg2)
        {
            var pos = new Vector3(0, bgBounds.size.y * 2, 0);
            target.position += pos;
        }
    }

    void Update()
    {
        bg1.position += Vector3.down * speed * Time.deltaTime;
        bg2.position += Vector3.down * speed * Time.deltaTime;
    }
}
