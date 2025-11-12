using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform topPipe;
    public Transform bottomPipe;
    public float gap = 2.8f;
    public float pipeHalfHeight = 2f;

    void Start()
    {
        UpdatePipePositions();
    }

    public void SetGap(float newGap)
    {
        gap = newGap;
        UpdatePipePositions();
    }

    void UpdatePipePositions()
    {
        // The midpoint of the pipe is this transform's position.
        float offset = pipeHalfHeight + gap / 2f;

        topPipe.localPosition = new Vector3(0, offset, 0);
        bottomPipe.localPosition = new Vector3(0, -offset, 0);
    }
}
