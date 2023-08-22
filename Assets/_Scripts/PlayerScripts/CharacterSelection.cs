using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Sprite[] playerSprites;
    public GameObject[] playerGameobjects;
    public int number;

    private void Start()
    {
        number = PlayerPrefs.GetInt("TemperoryNumber");
        PlayerUpdateList();
    }
    public void PlayerUpdateList()
    {
        switch (number)
        {
            case 0:
                if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
                {
                    playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[0].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
                {
                    playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[1].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
                {
                    playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[2].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
                {
                    playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[3].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
                {
                    playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[4].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                playerGameobjects[0].transform.GetComponent<Button>().interactable = true;

                playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);

                playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(false);

                GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite0")];
                PlayerPrefs.SetInt("PlayerSprite0", 0);
                break;
            case 1:
                if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
                {
                    playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[0].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
                {
                    playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[1].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
                {
                    playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[2].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
                {
                    playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[3].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
                {
                    playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[4].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                playerGameobjects[0].transform.GetComponent<Button>().interactable = true;

                playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);

                playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(false);

                GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite1")];
                PlayerPrefs.SetInt("PlayerSprite1", 1);
                break;
            case 2:
                if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
                {
                    playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[0].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
                {
                    playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[1].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
                {
                    playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[2].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
                {
                    playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[3].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
                {
                    playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[4].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                playerGameobjects[0].transform.GetComponent<Button>().interactable = true;

                playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);

                playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(false);

                GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite2")];
                PlayerPrefs.SetInt("PlayerSprite2", 2);
                break;
            case 3:
                if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
                {
                    playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[0].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
                {
                    playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[1].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
                {
                    playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[2].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
                {
                    playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[3].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
                {
                    playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[4].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                playerGameobjects[0].transform.GetComponent<Button>().interactable = true;

                playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);

                playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(false);

                GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite3")];
                PlayerPrefs.SetInt("PlayerSprite3", 3);
                break;
            case 4:
                if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
                {
                    playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[0].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
                {
                    playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[1].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
                {
                    playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[2].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
                {
                    playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[3].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
                {
                    playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                    playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);
                    playerGameobjects[4].transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "Owned";
                }
                playerGameobjects[0].transform.GetComponent<Button>().interactable = true;

                playerGameobjects[0].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[0].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[1].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[1].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[2].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[2].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[3].transform.GetChild(0).gameObject.SetActive(true);
                playerGameobjects[3].transform.GetChild(1).gameObject.SetActive(false);

                playerGameobjects[4].transform.GetChild(0).gameObject.SetActive(false);
                playerGameobjects[4].transform.GetChild(1).gameObject.SetActive(true);

                GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite4")];
                PlayerPrefs.SetInt("PlayerSprite4", 4);
                break;
        }
    }
    public void Player0Unlock()
    {
        if (0 == PlayerPrefs.GetInt("PlayerSprite0"))
        {
            number = PlayerPrefs.GetInt("PlayerSprite0");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
            return;
        }
        if (CurrencyManager.instance.Coins >= 100)
        {
            CurrencyManager.instance.coins -= 100;
            PlayerPrefs.SetInt("CoinBalance", CurrencyManager.instance.coins);
            CurrencyManager.instance.currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            PlayerPrefs.SetInt("PlayerSprite0", 0);
            number = PlayerPrefs.GetInt("PlayerSprite0");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
    public void Player1Unlock()
    {
        if (1 == PlayerPrefs.GetInt("PlayerSprite1"))
        {
            number = PlayerPrefs.GetInt("PlayerSprite1");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
            return;
        }
        if (CurrencyManager.instance.Coins >= 100)
        {
            CurrencyManager.instance.coins -= 100;
            PlayerPrefs.SetInt("CoinBalance", CurrencyManager.instance.coins);
            CurrencyManager.instance.currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            PlayerPrefs.SetInt("PlayerSprite1", 1);
            number = PlayerPrefs.GetInt("PlayerSprite1");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
    public void Player2Unlock()
    {
        if (2 == PlayerPrefs.GetInt("PlayerSprite2"))
        {
            number = PlayerPrefs.GetInt("PlayerSprite2");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
            return;
        }
        if (CurrencyManager.instance.Coins >= 100)
        {
            CurrencyManager.instance.coins -= 100;
            PlayerPrefs.SetInt("CoinBalance", CurrencyManager.instance.coins);
            CurrencyManager.instance.currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            PlayerPrefs.SetInt("PlayerSprite2", 2);
            number = PlayerPrefs.GetInt("PlayerSprite2");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
    public void Player3Unlock()
    {
        if (3 == PlayerPrefs.GetInt("PlayerSprite3"))
        {
            number = PlayerPrefs.GetInt("PlayerSprite3");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
            return;
        }
        if (CurrencyManager.instance.Coins >= 100)
        {
            CurrencyManager.instance.coins -= 100;
            PlayerPrefs.SetInt("CoinBalance", CurrencyManager.instance.coins);
            CurrencyManager.instance.currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            PlayerPrefs.SetInt("PlayerSprite3", 3);
            number = PlayerPrefs.GetInt("PlayerSprite3");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
    public void Player4Unlock()
    {
        if (4 == PlayerPrefs.GetInt("PlayerSprite4"))
        {
            number = PlayerPrefs.GetInt("PlayerSprite4");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
            return;
        }
        if (CurrencyManager.instance.Coins >= 100)
        {
            CurrencyManager.instance.coins -= 100;
            PlayerPrefs.SetInt("CoinBalance", CurrencyManager.instance.coins);
            CurrencyManager.instance.currentCoinText.text = "" + PlayerPrefs.GetInt("CoinBalance");
            PlayerPrefs.SetInt("PlayerSprite4", 4);
            number = PlayerPrefs.GetInt("PlayerSprite4");
            PlayerPrefs.SetInt("TemperoryNumber", number);
            PlayerPrefs.GetInt("TemperoryNumber");
            PlayerUpdateList();
        }
        else
        {
            UIPopupManager.Instance.Show("CoinsPanel");
        }
    }
}

