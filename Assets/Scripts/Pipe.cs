using UnityEngine;

public class Pipe : MonoBehaviour
{
  public Transform topPipe;
  public Transform bottomPipe;
  public float gap = 2.8f;

  float halfPipeHeight;   // 自动计算

  void Start()
  {
    // 自动从 topPipe 计算高度
    SpriteRenderer sr = topPipe.GetComponent<SpriteRenderer>();

    if (sr != null)
    {
      // 世界空间高度
      halfPipeHeight = sr.bounds.extents.y;
    }
    else
    {
      halfPipeHeight = 2f; // fallback
    }

    UpdatePipePositions();
  }

  public void SetGap(float newGap)
  {
    gap = newGap;
    UpdatePipePositions();
  }

  void UpdatePipePositions()
  {
    if (halfPipeHeight <= 0) return;

    float offset = halfPipeHeight + gap / 2f;

    topPipe.localPosition = new Vector3(0, offset, 0);
    bottomPipe.localPosition = new Vector3(0, -offset, 0);
  }
}
