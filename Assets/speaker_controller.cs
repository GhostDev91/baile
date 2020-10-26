using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speaker_controller : MonoBehaviour
{
    [SerializeField] GameObject particula;
    [SerializeField] GameObject particulaDos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticulas ()
    {
        particula.GetComponent<ParticleSystem>().Play();
        particulaDos.GetComponent<ParticleSystem>().Play();
    
    }
}
