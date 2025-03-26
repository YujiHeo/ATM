using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    { get { return instance; } }


    public UserData userData;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DataManager.instance.LoadData();
    }

    public void Update()
    {
        Refresh(userData.userName, userData.cash, userData.balance);
    }

    public void Refresh(string userName, int cash, int balance)
    {
        userData.userName = userName;
        userData.cash = cash;
        userData.balance = balance;

        UIManager.instance.UpdateUI(userName, cash, balance);
    }
}

