using TMPro;
using UnityEngine;

public class DropObjectCurrent : MonoBehaviour
{
    public static GameObject objectCurrent;

    public TextMeshProUGUI UIsunScore;

    private int lastSunScore; // Biến lưu giá trị điểm số trước đó

    private void Start()
    {
        // Kiểm tra xem GamePlay.instance có phải là null không
        if (GamePlay.instance != null)
        {
            lastSunScore = GamePlay.instance.sunScore;
            UpdateScoreText(); // Cập nhật điểm số ban đầu
        }
        else
        {
            Debug.LogError("GamePlay.instance is not set.");
        }
    }

    private void Update()
    {
        if (GamePlay.instance != null && GamePlay.instance.sunScore != lastSunScore)
        {
            lastSunScore = GamePlay.instance.sunScore;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        UIsunScore.text = GamePlay.instance.sunScore.ToString();
    }
}
