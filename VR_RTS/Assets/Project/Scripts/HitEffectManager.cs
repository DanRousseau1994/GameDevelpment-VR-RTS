using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public GameObject impactEffect;

    public void SpawnHitEffect()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}