using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Manue : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;


    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }
    public void OpenManeu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
