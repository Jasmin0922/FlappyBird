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

    private void Awake()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            Debug.LogError("GetReadyUIController 需要一个 CanvasGroup 组件！");

        // 初始直接显示
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void Start()
    {
        // 自动显示 displayTime 秒后淡出
        StartCoroutine(AutoHide());
    }

    IEnumerator AutoHide()
    {
        // 等待显示时间
        yield return new WaitForSeconds(displayTime);

        // 淡出
        yield return StartCoroutine(FadeOut(fadeDuration));
    }

    IEnumerator FadeOut(float duration)
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
