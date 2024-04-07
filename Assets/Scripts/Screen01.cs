using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Screen01 : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_Text txtEr;
    [SerializeField] private Screen02 sc02;
    float t = 0f, last_t=0f;
    float lastActionTime=0f;    
    int nState = 0;
    int res = 64;
    bool isEnteringPassword = false;
    bool isShowingWindow = false;
    bool isColorLines = false;

    void Start()
    {
        window.SetActive(false);
        
        _texture = new Texture2D(res, res);
        GetComponent<Renderer>().material.mainTexture = _texture;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t - last_t > 0.5f&& nState == 0)
        {
            //printStrings();
            drawCircle(Random.Range(0, res), Random.Range(0, res), Random.Range(0, res)/2, new Color(Random.value, Random.value, Random.value, 1f));
            last_t = t;
            sc02.reset();
        }

        if (nState == 1 && !isEnteringPassword) {
            drawRect(0, 0, res, res, new Color(0f, 0f, 0f, 1f));
            drawRect(5, 30, 50, 6, new Color(1f, 1f, 1f, 1f));
            drawRect(6, 31, 1, 4, new Color(0f, 0f, 0f, 1f));
            isEnteringPassword=true;
            sc02.setState(1);
        }
        if (nState == 2 && !isShowingWindow)
        {
            window.SetActive(true);
            isShowingWindow = true;
        }

        if (nState == 3 && !isColorLines)
        {
            drawRect(0, 0, 13, res-1, Color.red);
            drawRect(13, 0, 13, res-1, Color.yellow);
            drawRect(26, 0, 13, res-1, Color.blue);
            drawRect(39, 0, 13, res - 1, Color.green);
            drawRect(52, 0, 13, res - 1, new Color(1f, 0f, 0.5f, 1f));
            isColorLines=true;
            sc02.setState(3);
        }
        /*for (int x = 0; x < 64; x++)
            for (int y = 0; y < 64; y++)
                _texture.SetPixel(x, y, new Color(Random.value, Random.value, Random.value, 1f));
        _texture.Apply();*/
    }

    void printStrings()
    {
        for (int y = 0; y < res; y++)
            for (int x = 0; x < res; x++)
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

    void drawCircle(int x, int y, int r, Color col)
    {
        Vector2 center = new Vector2(x, y);
        Vector2 curP;
        Vector2 vec;
        for (int yy = 0; yy < res; yy++)
            for (int xx = 0; xx < res; xx++)
            {
                curP.x= xx; 
                curP.y= yy;
                vec = curP - center;
                if (vec.magnitude <= r)
                {
                    _texture.SetPixel(xx, yy, col);
                }
            }
        _texture.Apply();   
    }

    void drawRect(int x, int y, int dx, int dy,Color col)
    {
        for (int yy = y; yy < y+dy; yy++)
            for (int xx = x; xx < x+dx; xx++)
                _texture.SetPixel(xx, yy, col);
        _texture.Apply();
    }

    public void nextStep()
    {
        if (nState<3)
            nState++;
        //if (nState == 4) nState = 0;
    }

    public Vector2 getPosition()
    {
        Vector2 v = new Vector2(transform.position.x, transform.position.z);
        return v;
    }

    public int getState()
    {
        return nState;
    }

    public void reset()
    {
        nState = 0;
        isEnteringPassword = false;
        isShowingWindow = false;
        txt.text = "";
        passwordInput.text = "";
        txtEr.text = "";
        window.SetActive(false);
        sc02.reset();
    }

    public void pOK()
    {
        nState = 3;
        isEnteringPassword = false;
        isShowingWindow = false;
        txt.text = "";
        passwordInput.text = "";
        txtEr.text = "";
        window.SetActive(false);
    }
}
