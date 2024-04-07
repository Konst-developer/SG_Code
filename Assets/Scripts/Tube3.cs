using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube3 : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    int res = 1;
    int N = 5;
    Color[] cols = new Color[9];

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

        _texture.SetPixel(0, 0, cols[N]);
        _texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextColor()
    {
        N++;
        if (N == 9) N = 0;
        _texture.SetPixel(0, 0, cols[N]);
        _texture.Apply();
    }

    public int getColor()
    {
        return N;
    }

    public Vector2 getPosition()
    {
        Vector2 v = new Vector2(transform.position.x, transform.position.z);
        return v;
    }
}
