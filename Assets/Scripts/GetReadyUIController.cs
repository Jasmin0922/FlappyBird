using UnityEngine;
using System.Collections;

public class GetReadyUIController : MonoBehaviour
{
    [Header("CanvasGroup 用于淡入淡出")]
    public CanvasGroup canvasGroup;

    [Header("淡出速度")]
    public float fadeDuration = 0.5f;

    [Header("显示时间（秒）")]
    public float displayTime = 1.5f;

    [Header("是否自动开始游戏")]
    public bool autoStartGame = true;

    private bool hasFadedOut = false;

    private IEnumerator Start()
    {
        // 延迟一帧，确保 Unity 所有字体/UI 都在主线程初始化完毕
        yield return null;

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("GetReadyUIController 需要一个 CanvasGroup 组件！");
            yield break;
        }

        // 初始化 UI 显示
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // 等待显示时间
        yield return new WaitForSeconds(displayTime);

        // 开始淡出
        yield return StartCoroutine(FadeOut(fadeDuration));

        if (autoStartGame && !hasFadedOut)
        {
            hasFadedOut = true;

            // 如果有 GameManager，可以在这里触发游戏开始逻辑
            if (GameManager.instance != null)
            {
                Debug.Log("Get Ready UI 消失，游戏开始！");
                // 这里你可以调用 GameManager 的游戏启动逻辑
                // 比如 GameManager.instance.StartGame();
            }
        }
    }

    private IEnumerator FadeOut(float duration)
    {
        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
