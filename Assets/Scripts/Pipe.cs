using UnityEngine;

public class Pipe : MonoBehaviour
{
  public Transform topPipe;
  public Transform bottomPipe;
  public float gap = 2.8f;

  private const float defaultPipeHalfHeight = 2f;
  private float halfPipeHeight;

  void Start()
  {
    SpriteRenderer sr = topPipe.GetComponent<SpriteRenderer>();

    if (sr != null)
    {
      halfPipeHeight = sr.bounds.extents.y;
    }
    else
    {
      halfPipeHeight = defaultPipeHalfHeight;
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
    float offset = halfPipeHeight + gap / 2f;

    topPipe.localPosition = new Vector3(0, offset, 0);
    bottomPipe.localPosition = new Vector3(0, -offset, 0);
  }
}
