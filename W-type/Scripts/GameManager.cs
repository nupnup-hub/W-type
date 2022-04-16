using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance; 

    private int score = 0;
    public bool isGameover { get; private set; }
    public GameObject wave;
    public ScrollingObject scrollingObject;

    private void Awake()
    {
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    private void Enable()
    {
        wave.SetActive(false);
    }
    private void Start()
    {
        FindObjectOfType<PHealth>().onDeath += EndGame;
        FindObjectOfType<Boss>().onDeath += Clear;
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            UIManager.instance.UpdateScoreText(score);
        }
    }
    
    public void EndGame()
    {
        isGameover = true;
        AddScore(1000);
        UIManager.instance.SetActiveGameoverUI(true);
        wave.SetActive(false);
        scrollingObject.stop = true;
    }
    public void Clear()
    {
        UIManager.instance.SetActiveGameClearUI(true);
        wave.SetActive(false);
        scrollingObject.stop = true;
    }
}
