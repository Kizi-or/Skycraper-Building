using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    bool _audioSourceOneOnPlaying;
    bool _audioSourceTwoOnPlaying;

    void Start()
    {
        _audioSourceOneOnPlaying = true;
        _audioSourceTwoOnPlaying = false;
        AudioSource1.Play();
    }

    void Update()
    {
        if (!AudioSource1.isPlaying && _audioSourceOneOnPlaying is true)
        {
            _audioSourceOneOnPlaying = false;
            _audioSourceTwoOnPlaying = true;
            AudioSource2.Play();
        }
        if(!AudioSource2.isPlaying && _audioSourceTwoOnPlaying is true)
        {
            _audioSourceTwoOnPlaying = false;
            _audioSourceOneOnPlaying = true;
            AudioSource1.Play();
        }
    }
}





