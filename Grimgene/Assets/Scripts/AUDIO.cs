using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AUDIO : MonoBehaviour {



    public Slider Slider;
    public AudioSource BGAudio;

	// Use this for initialization
	void Start () {
        Slider.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
        BGAudio.volume = Slider.value;
		
	}
}
