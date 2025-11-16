using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;

  private AudioSource sfxSource;

  public AudioClip jumpSound;
  public AudioClip scoreSound;
  public AudioClip hitSound;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
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