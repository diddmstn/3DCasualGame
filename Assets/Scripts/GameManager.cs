using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager:MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool objectPool{get; private set;}
    public GameObject gameOvecrPanel;
    public TextMeshProUGUI coinCountText;
    int totalCoin=0;

    private void Awake() 
    {
        instance = this;
        objectPool= GetComponent<ObjectPool>();
    }
    private void Start() 
    {
        coinCountText.text=$"{totalCoin}";
    }

    public void GameOver()
    {
        Time.timeScale=0;
        gameOvecrPanel.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;
    }

    public void IncreaseCoin()
    {
        coinCountText.text = $"{++totalCoin}";
    }
}