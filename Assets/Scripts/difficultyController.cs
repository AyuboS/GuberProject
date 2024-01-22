using UnityEngine;

public class difficultyController : MonoBehaviour
{
    public GameObject difficultySelectionUI;

    public void SetEasyDifficulty()
    {
        difficultyManager.CurrentDifficulty = difficultyManager.Difficulty.Easy;
        difficultySelectionUI.SetActive(false); 
    }

    public void SetHardDifficulty()
    {
        difficultyManager.CurrentDifficulty = difficultyManager.Difficulty.Hard;
        difficultySelectionUI.SetActive(false);
    }
}
