using System;
using TMPro;
using UnityEngine.UI;

namespace Core.Settings
{
    using UnityEngine;

    public class SettingsController: MonoBehaviour {
        public TMP_Dropdown qualityDropdown;
        public TMP_Dropdown antialiasingDropdown;
        public TMP_Dropdown shadowQualityDropdown;
        public TMP_Dropdown anisotropicDropdown;
        public Toggle realtimeReflectionProbesToggle;
        public Slider mainVolumeSlider;
        public Slider menuVolumeSlider;
        public Slider trainVolumeSlider;
        private readonly string[] _anisotropicFilteringOptions = {"Disable", "Enable", "Force enable"};
        private readonly string[] _antialiasingOptions = {"Off", "2x", "4x", "8x"};
        private readonly string[] _shadowQualityOptions = {"Disable", "Hard Only", "Hard and soft"};
        private bool isUsingPredefinedGraphicSetting = false;
        private void Start()
        {
	        qualityDropdown.options.Clear();
	        antialiasingDropdown.options.Clear();
	        shadowQualityDropdown.options.Clear();
	        anisotropicDropdown.options.Clear();
            mainVolumeSlider.value = PlayerPrefs.GetInt("MainVolume", 0);
            menuVolumeSlider.value = PlayerPrefs.GetInt("UIVolume", 0);
            trainVolumeSlider.value = PlayerPrefs.GetInt("TrainVolume", 0);
            string loadedQualityPreset = PlayerPrefs.GetString("QualityPreset", "Unknown");
            foreach (var optionString in QualitySettings.names)
            {
                var option = new TMP_Dropdown.OptionData(optionString);
                qualityDropdown.options.Add(option);
            }

            foreach (var optionString in _shadowQualityOptions)
            {
                var option = new TMP_Dropdown.OptionData(optionString);
                shadowQualityDropdown.options.Add(option);
            }

            foreach (var optionString in _antialiasingOptions)
            {
                var option = new TMP_Dropdown.OptionData(optionString);
                antialiasingDropdown.options.Add(option);
            }

            foreach (var optionString in _anisotropicFilteringOptions)
            {
                var option = new TMP_Dropdown.OptionData(optionString);
                anisotropicDropdown.options.Add(option);
            }
			Debug.Log("Loaded quality preset: " + loadedQualityPreset);
            if (loadedQualityPreset == "Unknown")
            {
	            SetQualityPreset(1);
            } else if (loadedQualityPreset != "Custom")
			{
	            SetQualityPreset(Convert.ToInt32(loadedQualityPreset));
			}
            else
            {
	            LoadCustomQualitySettings();
            }
        }
        public void SetQualityPreset(int qualityIndex)
        {
	        isUsingPredefinedGraphicSetting = true;
            Debug.Log("Quality set to " + qualityIndex);
            PlayerPrefs.SetString("QualityPreset", qualityIndex.ToString());
            PlayerPrefs.Save();
            QualitySettings.SetQualityLevel(qualityIndex);
            realtimeReflectionProbesToggle.isOn = QualitySettings.realtimeReflectionProbes;
            qualityDropdown.value = QualitySettings.GetQualityLevel();
            shadowQualityDropdown.value = (int) QualitySettings.shadows;
            antialiasingDropdown.value = QualitySettings.antiAliasing;
            anisotropicDropdown.value = (int) QualitySettings.anisotropicFiltering;
        }

        private void LoadCustomQualitySettings()
		{
			Debug.Log("Shadow quality: " + PlayerPrefs.GetInt("CustomShadowQuality", 0));
			isUsingPredefinedGraphicSetting = false;
			realtimeReflectionProbesToggle.isOn = PlayerPrefs.GetInt("CustomRealTimeReflectionProbes", 0) == 1;
			ChangeDropdownValue(shadowQualityDropdown, PlayerPrefs.GetInt("CustomShadowQuality", 0));
			ChangeDropdownValue(antialiasingDropdown, PlayerPrefs.GetInt("CustomAntialiasing", 0));
			ChangeDropdownValue(anisotropicDropdown, PlayerPrefs.GetInt("CustomAnisotropic", 0));
		}

        private void ChangeDropdownValue(TMP_Dropdown dropdown, int newValue) {
	        dropdown.Select();
	        dropdown.value = newValue;
	        dropdown.RefreshShownValue();
        }

        public void SetMainVolume(int volume)
        {
            Debug.Log("Main volume set to " + volume);
            FMODUnity.RuntimeManager.GetBus("bus:/").setVolume(volume);
            PlayerPrefs.SetInt("MainVolume", volume);
            PlayerPrefs.Save();
        }

        public void SetMenuVolume(int volume)
        {
            Debug.Log("UI volume set to " + volume);
            FMODUnity.RuntimeManager.GetBus("bus:/UI").setVolume(volume);
            PlayerPrefs.SetInt("UIVolume", volume);
            PlayerPrefs.Save();
        }

        public void SetTrainVolume(int volume)
        {
            Debug.Log("Train volume set to " + volume);
            FMODUnity.RuntimeManager.GetBus("bus:/Train").setVolume(volume);
            PlayerPrefs.SetInt("TrainVolume", volume);
            PlayerPrefs.Save();
        }

        public void SetShadowQuality(int qualityIndex)
        {
            QualitySettings.shadows = (ShadowQuality) qualityIndex;
            PlayerPrefs.SetString("QualityPreset", "Custom");
            PlayerPrefs.SetInt("CustomShadowQuality", qualityIndex);
            PlayerPrefs.Save();
        }

        public void SetAntialiasing(int qualityIndex)
		{
			QualitySettings.antiAliasing = qualityIndex;
			PlayerPrefs.SetString("QualityPreset", "Custom");
			PlayerPrefs.SetInt("CustomAntialiasing", qualityIndex);
			PlayerPrefs.Save();
		}

		public void SetAnisotropic(int qualityIndex)
		{
			QualitySettings.anisotropicFiltering = (AnisotropicFiltering) qualityIndex;
			PlayerPrefs.SetString("QualityPreset", "Custom");
			PlayerPrefs.SetInt("CustomAnisotropic", qualityIndex);
			PlayerPrefs.Save();
		}

		public void SetRealtimeReflectionProbes(bool enable)
		{
			QualitySettings.realtimeReflectionProbes = enable;
			PlayerPrefs.SetString("QualityPreset", "Custom");
			PlayerPrefs.SetInt("CustomRealTimeReflectionProbes", enable ? 1 : 0);
			PlayerPrefs.Save();
		}
    }
}