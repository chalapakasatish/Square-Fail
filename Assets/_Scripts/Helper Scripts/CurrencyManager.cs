using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public int coins;
    public Text currentCoinText;
    public int potions;
    public Text currentPotionText;
    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        coins = PlayerPrefs.GetInt("CoinBalance",coins);
        potions = PlayerPrefs.GetInt("PotionBalance",potions);
        currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance",coins);
        currentPotionText.text = "" + PlayerPrefs.GetInt("PotionBalance",potions);
        PlayerPrefs.Save();
        //coins = PlayerPrefs.GetInt("CoinBalance");
        //potions = PlayerPrefs.GetInt("PotionBalance");
        //currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
        //currentPotionText.text = "" + PlayerPrefs.GetInt("PotionBalance");
    }
    public void AddCoinBalance(int value)
    {
        coins += value;
        PlayerPrefs.SetInt("CoinBalance",coins);
        currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
    }
    public void DeductCoinBalance(int value)
    {
        if(Coins >= value)
        {
            coins -= value;
            PlayerPrefs.SetInt("CoinBalance", coins);
            currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            switch(value)
            {
                case 50:
                    AddPotionBalance(1);
                    break;
                case 80:
                    AddPotionBalance(2);
                    break;
                case 120:
                    AddPotionBalance(3);
                    break;
            }
            
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
    public void AddPotionBalance(int value)
    {
        potions += value;
        PlayerPrefs.SetInt("PotionBalance", potions);
        currentPotionText.text = "" + PlayerPrefs.GetInt("PotionBalance");
        if(GameManager.instance.gameState == GameState.PLAYING)
        {
            UIPopupManager.Instance.Show("GameContinueWithPotion");
        }
    }
    public void DeductPotionBalance(int value)
    {
        if (potions >= value)
        {
            potions -= value;
            PlayerPrefs.SetInt("PotionBalance", potions);
            currentPotionText.text = "" + PlayerPrefs.GetInt("PotionBalance");
            //UIPopupManager.Instance.Hide("PotionPanel");
            GameManager.instance.GameContinue();
        }else
        {
            UIPopupManager.Instance.Show("PotionPanel");
            UIPopupManager.Instance.Hide("GameContinueWithPotion");
        }
    }
    public void NoAdsPack()
    {
        PlayerPrefs.SetInt("SHOW_ADS", 1);
    }
}
