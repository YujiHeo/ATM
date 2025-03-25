using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    public class CashData
    {
        public int cash;
        public int balance;

    }

    CashData nowCash;

    string filePath;

    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


        string floderpath = Path.Combine(Application.persistentDataPath, "Data");

        if (!Directory.Exists(floderpath))
        {
            Directory.CreateDirectory(floderpath);
        }

        filePath = Path.Combine(floderpath, "database.json");
    }

    public void SaveData()
    {
        nowCash.cash = GameManager.Instance.userData.cash; //userData를 바로 저장
        nowCash.balance = GameManager.Instance.userData.balance;

        string data = JsonUtility.ToJson(nowCash);

        File.WriteAllText(filePath, data);
    }
    

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            nowCash = JsonUtility.FromJson<CashData>(data);

            GameManager.Instance.userData.cash = nowCash.cash;
            GameManager.Instance.userData.balance = nowCash.balance;
        }
        else
        {
            nowCash = new CashData();
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
