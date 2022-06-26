using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Attach_GameObject_Light : MonoBehaviour
{
    public GameObject _prefab;

    private ParticleSystem _particleSystem;
    private List<GameObject> _instances = new List<GameObject>();
    private ParticleSystem.Particle[] _particles;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int count = _particleSystem.GetParticles(_particles);

        while (_instances.Count < count)
            _instances.Add(Instantiate(_prefab, _particleSystem.transform));

        bool worldSpace = (_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
        for (int i = 0; i < _instances.Count; i++)
        {
            if (i < count)
            {
                if (worldSpace)
                    _instances[i].transform.position = _particles[i].position;
                else
                    _instances[i].transform.localPosition = _particles[i].position;
                _instances[i].SetActive(true);
            }
            else
            {
                _instances[i].SetActive(false);
            }
        }
    }
}
