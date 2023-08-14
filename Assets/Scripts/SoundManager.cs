using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Start()
    {
        Bird.Instance.OnJump += Bird_OnJump;
        Bird.Instance.OnGetScore += Bird_OnGetScore;
        Bird.Instance.OnCollide += Bird_OnCollide;
    }

    private void Bird_OnCollide(object sender, System.EventArgs e)
    {
        Bird bird = sender as Bird;
        PlaySound(audioClipRefsSO.hit, bird.transform.position);
        PlaySound(audioClipRefsSO.die, bird.transform.position);
    }

    private void Bird_OnGetScore(object sender, System.EventArgs e)
    {
        Bird bird = sender as Bird;
        PlaySound(audioClipRefsSO.point, bird.transform.position);
    }

    private void Bird_OnJump(object sender, System.EventArgs e)
    {
        Bird bird = sender as Bird;
        PlaySound(audioClipRefsSO.wing, bird.transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
