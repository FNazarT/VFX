using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    private ParticleSystem fireParticle;
    public ParticleSystem rainParticle;
    public ParticleSystem igniteParticle;
    public ParticleSystem extinguishParticle;
    public GameObject pointLight;

    bool isFirePlaying = true;
    bool isRainPlaying = false;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isFirePlaying)
            {
                fireParticle.Stop();
                pointLight.SetActive(false);
                if (extinguishParticle != null)
                    extinguishParticle.Play();
                isFirePlaying = false;
            } 
            else
            {
                fireParticle.Play();
                pointLight.SetActive(true);
                if (igniteParticle != null)
                    igniteParticle.Play();
                isFirePlaying = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isRainPlaying)
            {
                rainParticle.Stop();
                isRainPlaying = false;
            }
            else
            {
                rainParticle.Play();
                isRainPlaying = true;
            }                
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (isFirePlaying)
        {
            Invoke(nameof(ExtinguishFire), 1f);
        }
    }

    private void ExtinguishFire()
    {
        fireParticle.Stop();
        pointLight.SetActive(false);
        if (extinguishParticle != null)
            extinguishParticle.Play();
        isFirePlaying = false;
    }
}
