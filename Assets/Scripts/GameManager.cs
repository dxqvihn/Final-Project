using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy; // bien so luong energy dang co
    [SerializeField] private int energyThreshold = 5; // so luong energy can nhat de trieu hoi boss
    [SerializeField] private GameObject boss; // tham chieu toi boss enemy
    [SerializeField] private GameObject enemySpaner;
    private bool bossCalled=false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUI;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseGameMenu;


    void Start()
    {
        currentEnergy = 0;
        UpdateEneryBar();
        boss.SetActive(false);   // khi game bat dau se an boss
        MainMenu();
    }

    
   

    public void AddEnergy()
    {
        if (bossCalled) // khi goi dc boss roi thi khong co cong energy hay goi enemy gi ca nua
        {
            return;
        }
        currentEnergy += 1;
        UpdateEneryBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }
    public void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpaner.SetActive(false); // khi boss xuat hien se ngung goi enemy khac
        gameUI.SetActive(false);
    }
    private void UpdateEneryBar()
    {
       if(energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 0f;

    }
    public void PauseGameMenu()
    {
        pauseGameMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
