using UnityEngine;

public class PlayVideoDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] videos;
    [SerializeField] private float videoClipLength;
    private int randomVideo;

    public float GetVideoTime()
    {
        return videoClipLength;
    }

    public void PlayDeath()
    {
        randomVideo = Random.Range(0, videos.Length - 1);
        videos[randomVideo].SetActive(true);
    }

}
