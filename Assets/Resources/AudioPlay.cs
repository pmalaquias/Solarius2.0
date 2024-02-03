using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AudioPlay : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips;

    ObserverBehaviour modelTargetBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        modelTargetBehaviour = GetComponent<ObserverBehaviour>();
        audioSource = gameObject.AddComponent<AudioSource>();
        modelTargetBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrackingFound(){
        // if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        // {
            Debug.Log("Tracking Found");
        // }
        
    }

    void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }

        else if(status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NOT_OBSERVED)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
