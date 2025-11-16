using UnityEngine;
using UnityEngine.UI;

public class GetReadyUIController : MonoBehaviour
{
  public CanvasGroup canvasGroup;

  private void Awake()
  {
    if (canvasGroup == null)
      canvasGroup = GetComponent<CanvasGroup>();

    canvasGroup.alpha = 1f;
    canvasGroup.interactable = true;
    canvasGroup.blocksRaycasts = true;
  }

  public void OnStartButtonPressed()
  {
    canvasGroup.alpha = 0f;
    canvasGroup.interactable = false;
    canvasGroup.blocksRaycasts = false;

    if (GameManager.instance != null)
    {
      GameManager.instance.StartGame();
    }
  }
}
