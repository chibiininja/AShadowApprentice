using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioClips;

    private void Start()
    {
        if (audioClips.Count == 0) {
            StartCoroutine("DestroySelf", GetComponent<AudioSource>().clip.length);
        }
        else
        {
            int index = UnityEngine.Random.Range(0, audioClips.Count);
            GetComponent<AudioSource>().clip = audioClips[index];
            StartCoroutine("DestroySelf", GetComponent<AudioSource>().clip.length);
        }
    }

    private IEnumerator DestroySelf(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
