using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioSource bass, drumSfxTimpani, melody, piano;
    bool bassOff, drumOff, melodyOff, pianoOff;
    public float drumStart,pianoStart,melodyStart,bassStart;
    public AudioSource synthSolo;
    public AudioSource slowSfx;
    public PlayerMovement player;
    void Start()
    {
        /*bassOff=true;
        drumOff=true;
        melodyOff=true;
        pianoOff=true;*/
        StartCoroutine(StartMusic());
    }

    // Update is called once per frame
    void Update()
    {
        piano.timeSamples = drumSfxTimpani.timeSamples;
        melody.timeSamples = drumSfxTimpani.timeSamples;
        bass.timeSamples = drumSfxTimpani.timeSamples;
        slowSfx.timeSamples = drumSfxTimpani.timeSamples;
        synthSolo.timeSamples = drumSfxTimpani.timeSamples;

        if(player.slow)
        {
            drumSfxTimpani.volume = 0f;
        }

        else if(!player.slow)
        {
            drumSfxTimpani.volume = 0.2f;
        }
    }

    public IEnumerator StartMusic()
    {
        drumSfxTimpani.Play();
        yield return new WaitForSeconds(drumSfxTimpani.clip.length);
        piano.Play();
        yield return new WaitForSeconds(piano.clip.length);
        melody.Play();
        yield return new WaitForSeconds(melody.clip.length);
        bass.Play();
    }

    public void StartSolo()
    {
        synthSolo.Play();
    }
}
