using System.Collections;

using UnityEngine;

public class MuzzleParticle : MonoBehaviour {
    [SerializeField] private ParticleSystem _particle;

    public void PlayAttackParticle() {
        if (_particle == null)
            return;

        _particle.gameObject.SetActive(true);
        _particle.Play();
        StartCoroutine(StopAttackParticle());
    }

    IEnumerator StopAttackParticle() {
        yield return new WaitForSeconds(1.5f);

        _particle.gameObject.SetActive(false);
        _particle.Stop();
    }
}
