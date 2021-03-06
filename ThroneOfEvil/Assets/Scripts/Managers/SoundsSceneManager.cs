﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigitalRuby.SoundManagerNamespace
{
public class SoundsSceneManager : MonoBehaviour {

		public Slider SoundSlider;
		public Slider MusicSlider;
		//public int SoundCountTextBox;//was input field
		//int count = 0;
		public Toggle PersistToggle;
		public AudioSource[] SoundAudioSources;
		public AudioSource[] MusicAudioSources;
		public int playSound;
		public int playMusic;

		public void PlaySound(int index)
		{
			SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
			/*int count;
            if (!int.TryParse(SoundCountTextBox.text, out count))
            {
                count = 1;
            }
            while (count-- > 0)
            {
                SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
            }*/
		}

		private void PlayMusic(int index)
		{
			MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 1.0f, PersistToggle.isOn);
		}

		private void CheckPlayKey()
		{
			/*if (SoundCountTextBox.isFocused)
			{
				return;
			}*/

			if (playSound == 1)
			{
				PlaySound(0);
			}
			if (playSound == 2)
			{
				PlaySound(1);
			}
			if (playSound == 3)
			{
				PlaySound(2);
			}
			if (playSound == 4)
			{
				PlaySound(3);
			}
			if (playSound == 5)
			{
				PlaySound(4);
			}
			if (playSound == 6)
			{
				PlaySound(5);
			}
			if (playSound == 7)
			{
				PlaySound(6);
			}
			if (playSound == 8)
			{
				PlaySound(7);
			}
			if (playSound == 9)
			{
				PlaySound(8);
			}
			if (playSound == 10)
			{
				PlaySound (9);
			}
			if (playSound == 11)
			{
				PlaySound (10);
			}
			if (playMusic== 1)
			{
				PlayMusic(0);
			}
			/*if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				PlayMusic(1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				PlayMusic(2);
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				PlayMusic(3);
			}*/
			if (Input.GetKeyDown(KeyCode.R))
			{
				Debug.LogWarning("Reloading level");

				if (!PersistToggle.isOn)
				{
					SoundManager.StopAll();
				}
				//UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, UnityEngine.SceneManagement.LoadSceneMode.Single);
			}
		}

		private void Start()
		{

		}

		private void Update()
		{
			CheckPlayKey();
		}

		public void SoundVolumeChanged()
		{
			SoundManager.SoundVolume = SoundSlider.value;
		}

		public void MusicVolumeChanged()
		{
			SoundManager.MusicVolume = MusicSlider.value;
		}
}
}