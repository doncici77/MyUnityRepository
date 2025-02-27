using UnityEngine;
using UnityEngine.UI;

// ������ �����ϴ� ������ �Ŵ���
public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        bestScoreUI.text = $"�ְ� ����: {bestScore}";
        currentScoreUI.text = $"���� ����: {currentScore}";
    }

    // �Ŵ��� ���� �����ϴ� �ʵ� ��
    // Inspector
    public Text currentScoreUI;
    public Text bestScoreUI;

    // Inner
    private int currentScore;
    private int bestScore;

    // ���������� ���� ������Ƽ ����
    // ���� ���� ���ٰ� ������ ����ó�� ������ �� �ֽ��ϴ�.
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 1. ���޹��� ���� ������ ������ �����˴ϴ�.
            currentScore = value;
            // 2. UI�� �ش� ���� ����˴ϴ�.
            currentScoreUI.text = $"���� ����: {currentScore}";

            if(currentScore > bestScore)
            {
                // �� ������ �ְ������� ���� �Ǹ�
                bestScore = currentScore;
                // UI�� ����
                bestScoreUI.text = $"�ְ� ����: {bestScore}";
                // ���ε����Ϳ��� �������� �����մϴ�.
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }
}
