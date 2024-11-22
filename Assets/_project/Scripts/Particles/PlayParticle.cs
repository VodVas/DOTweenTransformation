using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _spark;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wall _))
        {
            _spark.Play();
        }
    }
}