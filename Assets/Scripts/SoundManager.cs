using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;

  private AudioSource sfxSource;

  [Header("音效文件 (在 Inspector 中拖拽赋值)")]
  public AudioClip jumpSound;
  public AudioClip scoreSound;
  public AudioClip hitSound;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      // 确保 SoundManager 在场景重载时不被销毁 (可选)
      // DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    sfxSource = gameObject.AddComponent<AudioSource>();
    sfxSource.loop = false;
    sfxSource.playOnAwake = false;
  }

  public void PlaySFX(AudioClip clip)
  {
    if (sfxSource != null && clip != null)
    {
      sfxSource.PlayOneShot(clip);
    }
  }
}