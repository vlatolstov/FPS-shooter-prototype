using System.Collections;

using UnityEngine;

public class MuzzleParticle : MonoBehaviour {
    [SerializeField] private ParticleSystem _particle;

    public void PlayAttackParticle() {
        if (_particle == null)
            return;

        //_particle.Play();
        _particle.gameObject.SetActive(true);
        StartCoroutine(StopAttackParticle());
    }

    IEnumerator StopAttackParticle() {
        yield return new WaitForSeconds(1);

        //_particle.Stop();
        _particle.gameObject.SetActive(false);
    }
}
