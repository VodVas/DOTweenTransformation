using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wall _))
        {
            _sound.Play();
        }
    }
}