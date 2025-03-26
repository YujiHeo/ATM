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

    public class IDData
    {
        public string id;
        public string ps;
    }

    CashData nowCash;
    IDData iDData;

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
        nowCash.cash = GameManager.Instance.userData.cash; //userData∏¶ πŸ∑Œ ¿˙¿Â
        nowCash.balance = GameManager.Instance.userData.balance;
        iDData.id = GameManager.Instance.userData.ID;
        iDData.ps = GameManager.Instance.userData.Passward;

        string data = JsonUtility.ToJson(nowCash);
        string loginData = JsonUtility.ToJson(iDData);

        Debug.Log($"¿˙¿Âµ∆Ωøµ’{loginData}");

        File.WriteAllText(filePath, data);
        File.WriteAllText(filePath, loginData);
    }
    

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            nowCash = JsonUtility.FromJson<CashData>(data);

            string loginData = File.ReadAllText(filePath);
            iDData = JsonUtility.FromJson<IDData>(loginData);

            GameManager.Instance.userData.cash = nowCash.cash;
            GameManager.Instance.userData.balance = nowCash.balance;

            GameManager.Instance.userData.ID = iDData.id;
            GameManager.Instance.userData.Passward = iDData.ps;
        }
        else
        {
            nowCash = new CashData();
            iDData = new IDData();


            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
