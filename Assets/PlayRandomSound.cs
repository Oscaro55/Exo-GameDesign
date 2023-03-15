using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// With the courtesy of The Wild Games
public class PlayRandomSound : MonoBehaviour {
	
	[SerializeField]
	AudioClip[] listeSons;

	[SerializeField]
	float volumeMin = 0.9f, volumeMax = 1;
	[SerializeField]
	float pitchMin = 0.9f, pitchMax = 1;

	[SerializeField]
	AudioSource source;

	// Use this for initialization
	void Start () {
		source=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayRandom()
	{
		int idSon = Random.Range (0, listeSons.Length);
		source.clip=listeSons[idSon];
		source.volume = Random.Range (volumeMin, volumeMax);
		source.pitch = Random.Range (pitchMin, pitchMax);
		source.Play ();
	}
}
