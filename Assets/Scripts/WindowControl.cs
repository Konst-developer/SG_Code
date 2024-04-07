using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowControl : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private MoveControl mc;
    [SerializeField] private TMP_Text txtEr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void okPress()
    {
        if (passwordInput.text == "1961") {
            mc.setPasswordOk();
            txt.text = "";
            txtEr.text = "";
        }   
        else
        {
            passwordInput.text = "";
            txtEr.text = "Неверный пароль!";
        }
    }

    public void helpPress()
    {
        if (txt.text == "")
            txt.text = "В этом году впервые в истории человек покинул пределы Земли  и оказался в космосе.";
        else txt.text = "";
    }


}
