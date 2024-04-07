using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen01 : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    float t = 0f, last_t=0f;

    void Start()
    {
        _texture = new Texture2D(64, 64);
        GetComponent<Renderer>().material.mainTexture = _texture;

        _texture.SetPixel(5, 5, Color.red);
        _texture.SetPixel(6, 6, Color.red);
        _texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t - last_t > 0.5f)
        {
            printStrings();
            last_t = t;
        }
        /*for (int x = 0; x < 64; x++)
            for (int y = 0; y < 64; y++)
                _texture.SetPixel(x, y, new Color(Random.value, Random.value, Random.value, 1f));
        _texture.Apply();*/
    }

    void printStrings()
    {
        for (int y = 0; y < 64; y++)
            for (int x = 0; x < 64; x++)
            {
                if (y % 3!= 0) _texture.SetPixel(x, y, Color.black);
                else
                {
                    if(Random.value>0.25f) _texture.SetPixel(x, y, Color.white);
                    else _texture.SetPixel(x, y, Color.black);
                }
            }
        _texture.Apply();
    }
}
