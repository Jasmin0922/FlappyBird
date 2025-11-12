using UnityEngine;
using UnityEngine.UI;

public class GetReadyUIController : MonoBehaviour
{
    [Header("UI Canvas Group")]
    public CanvasGroup canvasGroup; // 显示整个 GetReady UI

    [Header("游戏自动开始?")]
    public bool autoStartGame = false; // 现在不自动开始

    private void Awake()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("GetReadyUIController 需要一个 CanvasGroup 组件！");
            return;
        }

        // 确保一开始 UI 显示
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnStartButtonPressed()
    {
        // 隐藏 GetReady UI
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        // 调用游戏开始逻辑
        if (GameManager.instance != null)
        {
            GameManager.instance.StartGame(); // 确保 GameManager 有 StartGame 方法
            Debug.Log("玩家按下按钮，游戏开始！");
        }
    }
}
