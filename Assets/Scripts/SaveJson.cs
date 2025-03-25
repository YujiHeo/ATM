using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveJson : MonoBehaviour
{
    class Data
    {
        public int cash;
        public int balance;
    }

    Data data = new Data() { cash = GameManager.Instance.userData.cash, balance = GameManager.Instance.userData.balance };

    // Start is called before the first frame update
    void Start()
    {
        string jsonData = JsonUtility.ToJson(data);

        Data data2 = JsonUtility.FromJson<Data>(jsonData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
