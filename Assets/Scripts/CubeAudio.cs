using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudio : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip ascend; 
    [SerializeField] private AudioClip descend;

    private AudioSource aud;
    private GlobalAudio globAud;

    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
        //aud.PlayOneShot(ascend);
        globAud = GameObject.Find("GameManager").GetComponent<GlobalAudio>();
    }

    public void PlayCollectionAudio(bool ascending)
    {
        globAud.pitchShift += 0.143f;
        if(globAud.pitchShift > 2) globAud.pitchShift = 1;
        aud.pitch = globAud.pitchShift;
        
        if(ascending == true)
        {
            
            aud.PlayOneShot(ascend);
        }
        else
        {
            aud.PlayOneShot(descend);
        }
    }
}
