using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public bool scrolling = true;
    public float scrollSpeed = 3;
    private void Update()
    {
        if(scrolling)
        ScrollBackGround();
    }
    private void ScrollBackGround()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World);
    }
}
