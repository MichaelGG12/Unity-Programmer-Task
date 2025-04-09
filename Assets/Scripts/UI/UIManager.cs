using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text feedbackText;

    public void ShowMessage(string message, float duration = 2f)
    {
        feedbackText.text = message;
        feedbackText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), duration);
    }

    private void HideMessage()
    {
        feedbackText.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}