using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositButton;
    public GameObject withdrawButton;

    public GameObject bankOption;

    public GameObject depositpopUp;
    public GameObject withdrawpopUp;

    public GameObject noCash;
    public GameObject noCashBackBtn;

    public TMP_InputField depositCashInput;
    public TMP_InputField withdrawCashInput;
    private string depositCash = null;
    private string withdrawCash = null;


    [SerializeField] UserData userData;

    /*
    public void Onclick()
    {
        ActiveDepositSystems();
        ActiveWithdrawSystems();

        CloseActiveSystems();

        PopupBankDepositing();
        PopupBankWithdrawing();

        CloseNoCashPopUp();
    }
    */

    public void ActiveDepositSystems() //�Ա� â ��Ƽ��
    {
        bankOption.SetActive(false);
        depositpopUp.SetActive(true);
    }

    public void ActiveWithdrawSystems() //��� â ��Ƽ��
    {
        bankOption.SetActive(false);
        withdrawpopUp.SetActive(true);
    }


    public void CloseActiveSystems()
    {
        depositCashInput.text = "0";
        withdrawCashInput.text = "0";

        depositpopUp.SetActive(false);
        withdrawpopUp.SetActive(false);

        bankOption.SetActive(true);
    }

    public void DepositCash(int cash)
    {

        if (GameManager.Instance.userData.cash >= cash)
        {
            GameManager.Instance.userData.cash -= cash;
            GameManager.Instance.userData.balance += cash;
        }
        else
        {
            noCash.SetActive(true);
        }

        DataManager.instance.SaveData();
    }

    public void WithdrawCash(int cash)
    {

        if (GameManager.Instance.userData.balance >= cash) //������Ƽ.......
        {
            GameManager.Instance.userData.cash += cash;
            GameManager.Instance.userData.balance -= cash;
        }
        else
        {
            noCash.SetActive(true);
        }
    }

    /*
    public void DepositCash10000() // Ư�� �ݾ� �Ա� ��ư
    {
        if (GameManager.Instance.userData.cash >= 10000)
        {
            GameManager.Instance.userData.cash -= 10000;
            GameManager.Instance.userData.balance += 10000;
        }
        else
        {
            noCash.SetActive(true);
            Debug.Log("���� ����");
        }
    }

    public void DepositCash30000() // Ư�� �ݾ� �Ա� ��ư
    {
        if (GameManager.Instance.userData.cash >= 30000)
        {
            GameManager.Instance.userData.cash -= 30000;
            GameManager.Instance.userData.balance += 30000;
        }
        else
        {
            noCash.SetActive(true);
            Debug.Log("���� ����");
        }
    }

    public void DepositCash50000() // Ư�� �ݾ� �Ա� ��ư
    {
        if (GameManager.Instance.userData.cash >= 50000)
        {
            GameManager.Instance.userData.cash -= 50000;
            GameManager.Instance.userData.balance += 50000;
        }
        else
        {
            noCash.SetActive(true);
            Debug.Log("���� ����");
        }
    }



    public void WithdrawCash10000() //Ư�� �ݾ� ��� ��ư
    {
        {
            if (GameManager.Instance.userData.cash >= 10000)
            {
                GameManager.Instance.userData.cash -= 10000;
                GameManager.Instance.userData.balance += 10000;
            }

            else
            {
                noCash.SetActive(true);
                Debug.Log("���� ����");
            }
        }
    }

    public void WithdrawCash30000()
    {
        {
            if (GameManager.Instance.userData.cash >= 30000)
            {
                GameManager.Instance.userData.cash -= 30000;
                GameManager.Instance.userData.balance += 30000;
            }

            else
            {
                noCash.SetActive(true);
                Debug.Log("���� ����");
            }
        }
    }

    public void WithdrawCash50000()
    {
        {
            if (GameManager.Instance.userData.cash >= 50000)
            {
                GameManager.Instance.userData.cash -= 50000;
                GameManager.Instance.userData.balance += 50000;
            }

            else
            {
                noCash.SetActive(true);
                Debug.Log("���� ����");
            }
        }
    }
    */




    public void PlusCash()
    {
        GameManager.Instance.userData.cash += 10000;
    }

    public void PlusBalance()
    {
        GameManager.Instance.userData.balance += 10000;
    }






    public void PopupBankDepositing() //Ŀ���� ��ǲ �Ա� �ݾ�
    {
        depositCash = depositCashInput.text;

        string depositCashStr = depositCashInput.text;
        int depositAmount;

        if (int.TryParse(depositCashStr, out depositAmount))
        {
            DepositCash(depositAmount);

            /*
            if (GameManager.Instance.userData.cash >= depositAmount)
            {
                GameManager.Instance.userData.cash -= depositAmount;
                GameManager.Instance.userData.balance += depositAmount;
            }
            */
        }
    }

    public void PopupBankWithdrawing() //Ŀ���� ��ǲ ��� �ݾ�
    {
        withdrawCash = withdrawCashInput.text;

        string withdrawCashStr = withdrawCashInput.text;
        int withdrawAmount;


        if (int.TryParse(withdrawCashStr, out withdrawAmount))
        {
            WithdrawCash(withdrawAmount);
            /*
            if (GameManager.Instance.userData.balance >= withdrawAmount)
            {
                GameManager.Instance.userData.cash += withdrawAmount;
                GameManager.Instance.userData.balance -= withdrawAmount;
            }

            else
            {
                noCash.SetActive(true);
                Debug.Log("���� ����");
            }
            */
        }
    }

    public void CloseNoCashPopUp() //���� ���� �˾� �ݱ� 
    {
        noCash.SetActive(false);
    }
}