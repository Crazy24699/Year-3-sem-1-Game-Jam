using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public float LifeTime;

    void Start()
    {
        StartCoroutine(LifeTimer());
    }

    public IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

}
