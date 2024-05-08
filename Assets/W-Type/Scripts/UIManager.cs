using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance;

    public Text scoreText;
    public Text gradeText;
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 
    public GameObject gameclearUI;
    public int score = 0;
    public int grade = 0;
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
        score += newScore;
        UpdateScoreText();
    }
    public void UpdateScoreText( )
    {
        if (score > 20000)
            grade = 3;
        else if (score > 15000)
            grade = 2;
        else
            grade = 1;
    }
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }
        
    public void SetActiveGameClearUI(bool active)
    {
        gameclearUI.SetActive(active);
        if (grade == 3)
            gradeText.text = "Stage clear \nyour grade is: A";
        else if (grade == 2)
            gradeText.text = "Stage clear \nyour grade is: B";
        else if (grade == 1)
            gradeText.text = "Stage clear \nyour grade is: C";
        else
            gradeText.text = "Stage clear \nyour grade is: D";
    }
    // 게임 재시작
    public void GameRestart()
    {
        SceneManager.LoadScene("Play");
    }
    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
