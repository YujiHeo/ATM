using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    private void Start()
    {
        ClearWindow();
    }

    void ClearWindow()
    {
        userNameText.text = string.Empty;
        cashText.text = string.Empty;
        balanceText.text = string.Empty;
    }


    public void UpdateUI(string userName, int cash, int balance)
    {
        userNameText.text = userName;
        cashText.text = cash.ToString();
        balanceText.text = balance.ToString();

        changeComma(cashText, balanceText);
    }

    public void changeComma(TextMeshProUGUI cashText, TextMeshProUGUI balanceText)
    {
        cashText.text = string.Format("{0:#,0}", int.Parse(cashText.text));
        balanceText.text = string.Format("{0:#,0}", int.Parse(balanceText.text));
    }
}
