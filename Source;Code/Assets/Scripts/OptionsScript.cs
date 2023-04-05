using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer MaVolumeMixer;
    public AudioMixer MuVolumeMixer;
    public void MasterVolume (float MaVolume){
        MaVolumeMixer.SetFloat("MaVolume", MaVolume);
    }
    public void MuVolume (float MuVolume){
        MuVolumeMixer.SetFloat("MuVolume", MuVolume);
    }
    public void QualityDropdown (int qualityInt){
        QualitySettings.SetQualityLevel(qualityInt);
    }

    public void FullScreen (bool IsFullS){
        Screen.fullScreen = IsFullS;
    }
}