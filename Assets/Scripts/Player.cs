using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip welcomeClip;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayWelcomeClip", 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > 0)
        {
            return;
        }
        transform.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime);
    }
    private void PlayWelcomeClip()
    {
        AudioSource.PlayClipAtPoint(welcomeClip, transform.position);
    }
}
