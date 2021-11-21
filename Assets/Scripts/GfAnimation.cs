using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GfAnimation : MonoBehaviour
{
    #region Variables
    public Animator gfAnimator;
    public Song song;
    public bool isLeft;
    public float bpm;
    public bool isReady;
    private float crocket, songPosition, lastBeat;
    #endregion

    public void Setup(float _bpm = 150)
    {
        bpm = _bpm;
        crocket = 60 / bpm;
        lastBeat = 0;
        songPosition = 0;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = song.musicSources[0].time;
        if (!isReady)
            return;

        if (songPosition >= lastBeat + crocket)
        {
            switch (isLeft)
            {
                case true:
                    gfAnimator.SetBool("IsLeft", false);
                    isLeft = false;
                    break;
                case false:
                    gfAnimator.SetBool("IsLeft", true);
                    isLeft = true;
                    break;
            }

            lastBeat += crocket;
        }
    }
}
