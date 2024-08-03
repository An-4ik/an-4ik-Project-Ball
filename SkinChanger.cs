
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using static Unity.VisualScripting.Icons;

public class SkinChanger : MonoBehaviour
{
    public Skin[] info;
    private bool[] StockCheck;

    public Button buyBttn;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI coinsText;
    public Transform player;
    public int index;

    public int coins;


    public int language; //изм языка
    

    private void Awake()
    {

        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenSkin");
        coinsText.text = coins.ToString();

        StockCheck = new bool[5];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");

        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];
            if (i == index)
                player.GetChild(i).gameObject.SetActive(true);
            else
                player.GetChild(i).gameObject.SetActive(false);
        }

        language = PlayerPrefs.GetInt("language", language); //загружаем язык
        if (language == 0)
        {
            priceText.text = "CHOSEN";
        } 
        else if (language == 1)
        {
            priceText.text = "ВЫБРАНО";
        }
        else if (language == 2)
        {
            priceText.text = "SEÇİLDİ";
        }
        buyBttn.interactable = false;
    }

    private void Start()
    {
       // language = PlayerPrefs.GetInt("language", language); //загружаем язык
    }
    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if (index < player.childCount - 1)
        {
            index++;

            if (info[index].inStock && info[index].isChosen)
            {
                if (language == 0)
                {
                    priceText.text = "CHOSEN";
                }
                else if (language == 1)
                {
                    priceText.text = "ВЫБРАНО";
                }
                else if (language == 2)
                {
                    priceText.text = "SEÇİLDİ";
                }
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                if (language == 0)
                {
                    priceText.text = "CHOOSE";
                }
                else if (language == 1)
                {
                    priceText.text = "ВЫБРАТЬ";
                }
                else if (language == 2)
                {
                    priceText.text = "SEÇMEK";
                }
                buyBttn.interactable = true;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);
            // Можно записать так:player.GetChild(i).gameObject.SetActive(false); player.GetChild(index-1).gameObject.SetActive(false);

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (info[index].inStock && info[index].isChosen)
            {
                if (language == 0)
                {
                    priceText.text = "CHOSEN";
                }
                else if (language == 1)
                {
                    priceText.text = "ВЫБРАНО";
                }
                else if (language == 2)
                {
                    priceText.text = "SEÇİLDİ";
                }
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                if (language == 0)
                {
                    priceText.text = "CHOOSE";
                }
                else if (language == 1)
                {
                    priceText.text = "ВЫБРАТЬ";
                }
                else if (language == 2)
                {
                    priceText.text = "SEÇMEK";
                }
                buyBttn.interactable = true;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void BuyButtonAction()
    {
        if (buyBttn.interactable && !info[index].inStock)
        {
            if (coins > int.Parse(priceText.text))
            {
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                info[index].inStock = true;
                 if (language == 0)
                {
                    priceText.text = "CHOOSE";
                }
                else if (language == 1)
                {
                    priceText.text = "ВЫБРАТЬ";
                }
                else if (language == 2)
                {
                    priceText.text = "SEÇMEK";
                }
                Save();
            }
        }

        if (buyBttn.interactable && !info[index].isChosen && info[index].inStock)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyBttn.interactable = false;
            if (language == 0)
            {
                priceText.text = "CHOSEN";
            }
            else if (language == 1)
            {
                priceText.text = "ВЫБРАНО";
            }
            else if (language == 2)
            {
                priceText.text = "SEÇİLDİ";
            }
        }
    }
}


[System.Serializable]
public class Skin
{
    public int cost;
    public bool inStock;
    public bool isChosen;
}