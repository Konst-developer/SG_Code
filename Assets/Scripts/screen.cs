using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    int res = 64;
    void Start()
    {
        _texture = new Texture2D(res, res);
        GetComponent<Renderer>().material.mainTexture = _texture;
        //drawRect(5, 5, 20, 20, new Color(1f, 0f, 0f, 1f));
        // drawCircle(32, 32, 20, new Color(0f, 0f, 1f, 1f));
        drawPasswordScreen();
    }

    // Update is called once per frame
    void Update()
    {/*
        for (int y = 0; y < res; y++)
            for (int x = 0; x < res; x++)
                _texture.SetPixel(x, y, new Color(Random.value, Random.value, Random.value, 1f));
        _texture.Apply();
        drawCircle(Random.Range(0, res), Random.Range(0, res), Random.Range(0, res / 2), new Color(Random.value, Random.value, Random.value, 1f));
    }*/
    }

    void drawRect(int x, int y, int dx, int dy, Color col)
    {
        for(int xx=x; xx<x+dx; xx++)
            for (int yy = y; yy <y+ dy; yy++)
                _texture.SetPixel(xx, yy, col);
        _texture.Apply();

    }

    void drawCircle(int x, int y, int r, Color col)
    {
        for (int xx = 0; xx < res; xx++)
            for (int yy = 0; yy < res; yy++)
                if (Mathf.Sqrt((xx - x) * (xx - x) + (yy - y) * (yy - y)) <= r)
                    _texture.SetPixel(xx, yy, col);
        _texture.Apply();
    }

    void drawPasswordScreen()
    {
        drawRect(0, 0, res, res, new Color(0f, 0f, 0f, 1f));
        drawRect(2, 30, 60, 6, new Color(1f, 1f, 1f, 1f));
            drawRect(3, 31, 1, 4, new Color(0f, 0f, 0f, 1f));
    }
}
