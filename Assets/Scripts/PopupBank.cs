using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataManager;

public class PopupBank : MonoBehaviour
{
    public GameObject loginWindow;
    public Button loginBtn;
    public Button signUpBtn;

    public TMP_InputField idInput;
    public TMP_InputField psInput;

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

    public void Start()
    {
        Button btn = signUpBtn.GetComponent<Button>();
        btn.onClick.AddListener(SignUp);

        Button loginbtn = loginBtn.GetComponent<Button>();
        loginbtn.onClick.AddListener(Login);
    }

    public void SignUp()
    {
        GameManager.Instance.userData.ID = idInput.text;
        GameManager.Instance.userData.Passward = psInput.text;

        DataManager.instance.SaveData();
    }

    public void Login()
    {
        if (GameManager.Instance.userData.ID == idInput.text && GameManager.Instance.userData.Passward == psInput.text)
        {
            ClosedLoginWindow();
        }

        else
        {
            Debug.Log("a Salt!");
        }
    }


    public void ClosedLoginWindow()
    {
        loginWindow.SetActive(false);
    }


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
        }
    }

    public void CloseNoCashPopUp() //���� ���� �˾� �ݱ� 
    {
        noCash.SetActive(false);
    }
}