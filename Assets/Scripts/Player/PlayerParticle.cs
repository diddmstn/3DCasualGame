using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private ParticleSystem effect;    

    public void ParticleActive()
    {
        effect.Stop();
        effect.Play();
    }
}
