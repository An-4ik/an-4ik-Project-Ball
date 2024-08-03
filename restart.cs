
using UnityEngine;
using UnityEngine.SceneManagement;
//using static Unity.VisualScripting.Icons;
public class restart : MonoBehaviour
{

    public int language; //изм языка
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        language = PlayerPrefs.GetInt("language", language);

    }




    public void EnglishLanguage()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void RussianLanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void TurkeyLanguage()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }
}

