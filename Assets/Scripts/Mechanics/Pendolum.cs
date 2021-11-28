using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendolum : MonoBehaviour
{
    public bool isAtLowestPoint, isActive, shouldIncreaseHypnosys;
    public GameObject sprite, staticHypno;
    public Image staticImage;
    public Song song;
    public Animator pendolumAnimator;
    public float bpm;
    private float crocket;
    public float hypnosisLevel;

    private void Start()
    {
        staticImage = staticHypno.GetComponent<Image>();
        staticHypno.SetActive(false);
    }

    public void Setup(float _bpm = 150)
    {
        if (!GlobalValues.pendolumEnabled)
        {
            sprite.SetActive(false);
            staticHypno.SetActive(false);
            isActive = false;
            shouldIncreaseHypnosys = false;
        }
        else
        {
            sprite.SetActive(true);
            staticHypno.SetActive(true);
            staticImage.color = new Color(1f, 1f, 1f, 0f);
            bpm = _bpm;
            crocket = 60 / bpm;
            pendolumAnimator.speed = 1 / crocket;
            hypnosisLevel = 0;
            isActive = true;
            shouldIncreaseHypnosys = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (hypnosisLevel < 0f)
        {
            hypnosisLevel = 0f;
        }

        if (hypnosisLevel >= 100f)
        {
            song.health = 0f;
        }

        staticImage.color = new Color(1f, 1f, 1f, hypnosisLevel / 100);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAtLowestPoint)
            {
                Debug.Log("Timed");
                hypnosisLevel -= 4f;
                StopCoroutine(Hit());
                StartCoroutine(Hit());
            }
            else
            {
                Debug.Log("Not timed");
                StopAllCoroutines();
                shouldIncreaseHypnosys = true;
                hypnosisLevel += 3f;
            }
        }
    }

    IEnumerator Hit()
    {
        shouldIncreaseHypnosys = false;

        yield return new WaitForSecondsRealtime(2.5f);

        shouldIncreaseHypnosys = true;
    }

    public void IncreaseHypnosys()
    {
        if (!isActive)
        {
            return;
        }
        if (shouldIncreaseHypnosys)
        {
            hypnosisLevel += 3f;
        }
    }

    public void SetLowestPoint(float value)
    {
        if (value == 0)
        {
            isAtLowestPoint = false;
        }
        if (value == 1)
        {
            isAtLowestPoint = true;
        }
    }
}
