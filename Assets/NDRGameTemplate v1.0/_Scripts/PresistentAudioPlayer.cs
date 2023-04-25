using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

namespace NDRGameTemplate
{
    [RequireComponent(typeof(AudioSource))]
    public class PresistentAudioPlayer : MonoBehaviour
    {
        public static PresistentAudioPlayer instance;
        [SerializeField] AudioSource audioPlayer;
        bool initAudio = false;
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] AudioClip[] musicTracks;
        [SerializeField] AudioMixerSnapshot[] fullAudio, muteBGM;
        [SerializeField] float transitionTime = 0.5f;

        private void Awake()
        {
            if (!instance)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
                if (audioPlayer == null)
                    audioPlayer = GetComponent<AudioSource>();
                audioPlayer.Play();
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if(!initAudio)
            {
                SetAudioVolume();
            }
        }
        public void SetAudioVolume(float bgm , float sfx)
        {
            audioPlayer.outputAudioMixerGroup.audioMixer.SetFloat("BGMVolume",
                                SettingToMixerValue(bgm));
            audioPlayer.outputAudioMixerGroup.audioMixer.SetFloat("SFXVolume",
               SettingToMixerValue(sfx));
        }
        private void SetAudioVolume()
        {
            audioPlayer.outputAudioMixerGroup.audioMixer.SetFloat("BGMVolume",
                                SettingToMixerValue(SaveManager.LoadSettingF(UISettingsMenu.musicPref)));
            audioPlayer.outputAudioMixerGroup.audioMixer.SetFloat("SFXVolume",
               SettingToMixerValue(SaveManager.LoadSettingF(UISettingsMenu.sfxPref)));
        }

        public void ChangeMusic(int tracks)
        {
            StartCoroutine(RunChangeMusic(tracks));
        }

        private IEnumerator RunChangeMusic(int tracks)
        {
            if (musicTracks[tracks] == audioPlayer.clip) yield break;
            else
            {
                audioMixer.TransitionToSnapshots(muteBGM, new float[] { 1.0f }, transitionTime);
                yield return new WaitForSeconds(transitionTime);
                audioPlayer.clip = musicTracks[tracks];
                audioPlayer.Play();
                audioMixer.TransitionToSnapshots(fullAudio, new float[] { 1.0f }, transitionTime);
            }
        }

        private float SettingToMixerValue(float settingValue) => (1f - settingValue) * 35f - 35f;
    }
}
