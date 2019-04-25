using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinyRenderer : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject point;
    public GameObject canvas;

    void Start()
    {
        var layout = canvas.GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = width;
        var canvasScaler = canvas.GetComponent<CanvasScaler>();
        layout.cellSize=new Vector2(canvasScaler.referenceResolution.x/width,canvasScaler.referenceResolution.y/height);

        //init pixels
        for (int i = 0; i < width * height; i++)
        {
            var pixelGo = Object.Instantiate<GameObject>(point);
            var pixel = pixelGo.GetComponent<Image>();
            pixel.transform.SetParent(canvas.transform);
            pixel.transform.localScale = Vector3.one;
            pixel.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), 
                Random.Range(0f,1f), Random.Range(0f,1f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
