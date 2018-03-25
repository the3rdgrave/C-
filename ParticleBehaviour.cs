using UnityEngine;
using System.Collections;

public class ParticleBehaviour : MonoBehaviour
{
    ParticleSystem ps;
    //enables prefab
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    //destroys it
    // Update is called once per frame
    void Update()
    {
        if (!ps.IsAlive())
            Destroy(gameObject);
    }
}
