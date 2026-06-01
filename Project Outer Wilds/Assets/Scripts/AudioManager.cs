using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public AudioClip[] levelMusic;
    public AudioSource sourcePrefab;
    public AudioSource levelMusicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*
    private void Start()
    {
        LevelMusicIndex(0);
    }
    */

    public void LevelMusicIndex(int index)
    {
        levelMusicSource.clip = levelMusic[index];
        levelMusicSource.Play();
    }

    public void PlayClip(AudioClip clip, float pitch = 1f)
    {
        AudioSource source = Instantiate(sourcePrefab);

        source.clip = clip;
        source.pitch = pitch;
        source.volume = 1f;

        source.Play();

        DontDestroyOnLoad(source);

        Destroy(source.gameObject, clip.length);
    }
}
