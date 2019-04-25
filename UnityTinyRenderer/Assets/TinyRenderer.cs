using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyRenderer : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject point;
    public GameObject canvas;

    void Start()
    {
        for (int i = 0; i < width*height; i++)
        {
            Object.Instantiate<GameObject>(point).transform.SetParent(canvas.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
