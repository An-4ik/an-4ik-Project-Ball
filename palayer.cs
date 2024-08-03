using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class palayer : MonoBehaviour
{

    public int language; //изм €зыка


    public AudioSource audio1;

    //ќчки
    [SerializeField] private TMP_Text score;
    private float _score = 1f;

    //public TMP_Text CoinsText;


    //окно проигрыша
    [SerializeField] public GameObject losePanel;

    //ћонетки
    [SerializeField] private TMP_Text CoinsText;
    private int coins;

    //звук монетки
    public AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        coins = PlayerPrefs.GetInt("coins");
        CoinsText.text = coins.ToString();

    
    }
    //касание - унечтожение
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy(this.gameObject);
            losePanel.SetActive(true);
            Time.timeScale = 0;
            //audioSource.SetActive(false);
            audio1.Stop();
            Debug.Log("USPEH!");
        }
        else if (other.gameObject.CompareTag("Coin")) //добыча монеток
        {
            audioSource.PlayOneShot(clip);
            coins++;
            CoinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coins", coins);

            Destroy(other.gameObject);
            // Coin.text = (coins).ToString();
        }
    }


    [SerializeField] private float rotationSpeed = 10f;
    void FixedUpdate()
    {
        //¬рашение
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (Time.timeScale != 0)
        {

            //накопление и вывод очков
            _score = _score + 0.05f;
            score.text = Math.Floor(_score).ToString();
        }
    }




}
