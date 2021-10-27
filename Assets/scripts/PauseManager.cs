using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool m_IsPaused { get; set; }

    [Header("Scenes")]
    public string m_QuitSceneName = "Menu";
    public string m_RestartSceneName = "MainGame";

    [Header("Buttons")]
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    public Button GOrestartButton;
    public Button GOquitButton;

    [Header("Panel")]
    public GameObject m_Panel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        //Button resumeButton = m_Panel.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Button>();
        resumeButton.onClick.AddListener(() => Hide());

        //Button quitButton = m_Panel.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Button>();
        quitButton.onClick.AddListener(() => {
            Hide();
            SceneManager.LoadScene(m_QuitSceneName);
        });

        GOquitButton.onClick.AddListener(() => {
            Hide();
            SceneManager.LoadScene(m_QuitSceneName);
        });

        restartButton.onClick.AddListener(() => {
            Hide();
            SceneManager.LoadScene(m_RestartSceneName);
        });

        GOrestartButton.onClick.AddListener(() => {
            Hide();
            SceneManager.LoadScene(m_RestartSceneName);
        });

        m_Panel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Show()
    {
        m_Panel.SetActive(true);
        Time.timeScale = 0.0f;
        m_IsPaused = true;
    }

    public void Hide()
    {
        m_Panel.SetActive(false);
        Time.timeScale = 1.0f;
        m_IsPaused = false;
    }

    public void ChangePauseStatus()
    {
        if (m_IsPaused)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseStatus();
        }
    }
}
