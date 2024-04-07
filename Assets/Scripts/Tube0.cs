using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube0 : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    float t = 0f, last_t = 0f;
    int res = 1;
    int N = 0;
    Color[] cols=new Color[9];// = {Color.red, Color.yellow, Color.blue, Color.green, Color.pink, Color.black, Color.white, new Color(0.7f,0.7f,1f,1f), Color.magenta};
    
    void Start()
    {
        _texture = new Texture2D(res, res);
        GetComponent<Renderer>().material.mainTexture = _texture;
        cols[0] = Color.red;
        cols[1] = Color.yellow;
        cols[2] = Color.blue;
        cols[3] = Color.green;
        cols[4] = new Color(1f, 0f, 0.5f, 1f);
        cols[5] = Color.black;
        cols[6] = Color.white;
        cols[7] = new Color(0.5f, 0.5f, 1f, 1f);
        cols[8] = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t - last_t > 1)
        {
            _texture.SetPixel(0, 0, cols[N]);
            _texture.Apply();
            N++;
            if (N == 9) N = 0;
            last_t = t;
        }

    }
}
