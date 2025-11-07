using UnityEngine;

/// <summary>
/// Simple infinite texture scroller using material.mainTextureOffset.
/// Attach to the Quad (or object with a Renderer).
/// </summary>
[RequireComponent(typeof(Renderer))]
public class BackgroundScroller : MonoBehaviour
{
    public Vector2 direction = new Vector2(1f, 0f); // scroll to the right (1,0) or left (-1,0)
    public float speed = 0.5f; // units per second
    public bool useSharedMaterial = false; // true: modifies material asset; false: creates instance

    Renderer rend;
    Material matInstance; // instance created at runtime when useSharedMaterial==false

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (useSharedMaterial)
        {
            // operate on sharedMaterial (modifies asset — affects all objects using that material)
            // Use with care (good for many identical backgrounds).
        }
        else
        {
            // create a runtime instance so we don't change the original asset
            matInstance = rend.material; // this creates a unique material instance
        }
    }

    void Update()
    {
        Vector2 delta = direction.normalized * (speed * Time.deltaTime);

        if (useSharedMaterial)
        {
            var mat = rend.sharedMaterial;
            if (mat != null)
            {
                Vector2 offset = mat.mainTextureOffset;
                offset += delta;
                mat.mainTextureOffset = offset;
            }
        }
        else
        {
            if (matInstance != null)
            {
                Vector2 offset = matInstance.mainTextureOffset;
                offset += delta;
                matInstance.mainTextureOffset = offset;
            }
        }
    }

    void OnDestroy()
    {
        // If we created a runtime instance with rend.material, we should destroy it to avoid leaks in editor/play mode.
        if (matInstance != null)
        {
            Destroy(matInstance);
        }
    }
}
