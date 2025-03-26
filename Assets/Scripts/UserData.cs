using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public enum DataType
{
    UserName,
    Cash,
    Balance,
    ID,
    Passward
}

[System.Serializable]
public class UserData
{
    [Header("Info")]
    public string userName;
    public int cash;
    public int balance;
    public string ID;
    public string Passward;
}

