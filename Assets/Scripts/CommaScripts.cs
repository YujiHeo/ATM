using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommaScripts : MonoBehaviour
{
    UserData userData;
    public int value;


    private void Awake()
    {
        userData = GetComponent<UserData>();
    }


    private void Start()
    {
        //userData.cash = GetComma(value);
    }

    public string GetComma(int value)
    {
        return string.Format("{0:#,0}", value);
    }
}