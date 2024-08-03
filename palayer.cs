using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class palayer : MonoBehaviour
{

    public int language; //��� �����


    public AudioSource audio1;

    //����
    [SerializeField] private TMP_Text score;
    private float _score = 1f;

    //public TMP_Text CoinsText;


    //���� ���������
    [SerializeField] public GameObject losePanel;

    //�������
    [SerializeField] private TMP_Text CoinsText;
    private int coins;

    //���� �������
    public AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        coins = PlayerPrefs.GetInt("coins");
        CoinsText.text = coins.ToString();

    
    }
    //������� - �����������
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
        else if (other.gameObject.CompareTag("Coin")) //������ �������
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
        //��������
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (Time.timeScale != 0)
        {

            //���������� � ����� �����
            _score = _score + 0.05f;
            score.text = Math.Floor(_score).ToString();
        }
    }




}
