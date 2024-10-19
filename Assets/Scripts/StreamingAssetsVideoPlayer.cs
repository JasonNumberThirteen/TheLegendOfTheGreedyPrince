using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class StreamingAssetsVideoPlayer : MonoBehaviour
{
	[SerializeField] private string filename;

	private VideoPlayer videoPlayer;

	private void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer>();
	}

	private void Start()
	{
		videoPlayer.url = VideoURL();
		
		videoPlayer.Play();
	}

	private string VideoURL() => System.IO.Path.Combine(Application.streamingAssetsPath, filename);
}