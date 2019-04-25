using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawPointUITest : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject point;
    public GameObject canvas;

    void Start()
    {


        //init pixels
        for (int i = 0; i < width * height; i++)
        {
            var pixelGo = Object.Instantiate<GameObject>(point);
            var pixel = pixelGo.GetComponent<Image>();
            pixel.transform.SetParent(canvas.transform);
            pixel.transform.localScale = Vector3.one;
            pixel.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),
                Random.Range(0f, 1f), Random.Range(0f, 1f));
            pixel.color=new Color(0.2f,0.1f,0.5f,1f);
        }


        var layout = canvas.GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = width;
        var canvasScaler = canvas.GetComponent<CanvasScaler>();


        float realWHRate = (float)Screen.width / Screen.height;
        float refWHRate = canvasScaler.referenceResolution.x / canvasScaler.referenceResolution.y;
        if (realWHRate > refWHRate)
        {
            var h = canvasScaler.referenceResolution.y / height;
            var w = canvasScaler.referenceResolution.y * realWHRate / width;

            layout.cellSize = new Vector2(w, h);
        }
        else
        {
            var w = canvasScaler.referenceResolution.x / width;
            var h = canvasScaler.referenceResolution.x / realWHRate / height;
            layout.cellSize = new Vector2(w, h);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("height:"+Screen.height);
        //Debug.Log("width:"+Screen.width);
        //Debug.Log("current"+Screen.currentResolution);



    }
}
