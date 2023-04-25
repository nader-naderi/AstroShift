using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class UISettingsMenu : MonoBehaviour
    {
        [SerializeField] Text titleTxt;
        [SerializeField]
        GameObject[] panels;

        [Header("Video Options")]
        [SerializeField] UIDropdown resolutionsDropdown;
        [SerializeField] UIDropdown qualityDropdown;
        [SerializeField] UIControl antiAliasingControl;
        [SerializeField] UIControl shadowsControl;
        [SerializeField] UIControl fullscreenControl;
        [SerializeField] UIControl vsyncControl;
        [SerializeField] UIDropdown textureQualityDropdown;

        [Header("Controls Options")]
        [SerializeField] Slider mouseSensitivity;
        [SerializeField] UIControl invertedMouse;
        [SerializeField] GameObject[] ControlOptionPanels;

        [SerializeField] UIKeyBinder[] lookBindingKeyes;
        [SerializeField] UIKeyBinder[] moveBindingKeyes;
        [SerializeField] UIKeyBinder[] combatBindingKeyes;
        [SerializeField] UIKeyBinder[] interactBindingKeyes;
        [SerializeField] UIKeyBinder[] multiplayerBindingKeyes;

        [Header("Sound Options")]
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider sfxSlider;

        [Header("Gameplay Options")]
        [SerializeField] UIControl enableConsoleControl;
        [SerializeField] UIControl subtitleControl;
        [SerializeField] UIControl enableCrosshairControl;
        [Header("MessageBoxes")]

        /// <summary>
        /// when the player changes a setting, and wanted to save, this will popup. Yes/NO
        /// </summary>
        [SerializeField] private GameObject areYouOkayWithChangesPanel;
        /// <summary>
        /// Keybinding.
        /// </summary>
        [SerializeField] private GameObject pressAnyKeyYouWantToApplyPanel;
        
        
        public static string musicPref = "Music";
        public static string sfxPref = "SFX";
        public static string resolutionPref = "Resolution";
        public static string qualityPref = "QualityLevel";
        public static string antialiasingPref = "AntiAliasing";
        public static string shadowPref = "Shadow";
        public static string vsyncPref = "vSync";
        public static string texturesQualityPref = "TexturesQuality";
        public static string fullscreenPref = "IsFullscreen";
        public static string mouseSensitivityPref = "MouseSensitivity";
        public static string invertedMousePref = "IsMouseInverted";

        public static string enableConsolePref = "IsConsoleEnabled";
        public static string subtitlePref = "IsSubtitleEnabeld";
        public static string crosshairPref = "IsCrosshairEnabled";

        private Resolution[] resolutions;

        private string currentkeyType = string.Empty;
        private int currentkeyIndex = -1;

        /// <summary>
        /// this field.
        /// </summary>
        public bool IsOnBindingKeyState { get; private set; } = false;


        private void Start()
        {
            resolutions = Screen.resolutions;
            InitializeResolution();
            ChangeWindow(0);
            LoadSettings();
        }

        private void OnGUI()
        {
            if (!IsOnBindingKeyState || currentkeyIndex < 0 || currentkeyType == string.Empty) return;

            Event keyEvent;

            KeyCode selectedKey = KeyCode.None;

            keyEvent = Event.current;

            if (keyEvent.isKey)
            {
                selectedKey = keyEvent.keyCode;

                // TODO: Find out if this selected key has been on the current keyboard list.
                // if true : return.

                if (selectedKey == KeyCode.Escape)
                {
                    
                    currentkeyType = string.Empty;
                    currentkeyIndex = -1;
                    ToggleKeyboardBindingPhase(false);
                    return;
                }

                switch (currentkeyType)
                {
                    case "look":
                        lookBindingKeyes[currentkeyIndex].Bind(selectedKey);
                        break;
                    case "move":
                        moveBindingKeyes[currentkeyIndex].Bind(selectedKey);
                        break;
                    case "combat":
                        combatBindingKeyes[currentkeyIndex].Bind(selectedKey);
                        break;
                    case "interact":
                        interactBindingKeyes[currentkeyIndex].Bind(selectedKey);
                        break;
                    case "multiplayer":
                        multiplayerBindingKeyes[currentkeyIndex].Bind(selectedKey);
                        break;
                    default:
                        break;
                }

                currentkeyType = string.Empty;
                currentkeyIndex = -1;
                ToggleKeyboardBindingPhase(false);
            }
        }

        private void Update()
        {
            
        }

        private void LoadSettings()
        {
            // Audio
            musicSlider.value = 1f - SaveManager.LoadSettingF(musicPref);
            sfxSlider.value = 1f - SaveManager.LoadSettingF(sfxPref);

            // Video.
            fullscreenControl.currentValue = SaveManager.LoadSetting(fullscreenPref);
            resolutionsDropdown.Dropdown.value = SaveManager.LoadSetting(resolutionPref);
            qualityDropdown.Dropdown.value = SaveManager.LoadSetting(qualityPref);
            antiAliasingControl.currentValue = SaveManager.LoadSetting(antialiasingPref);
            shadowsControl.currentValue = SaveManager.LoadSetting(shadowPref);
            vsyncControl.currentValue = SaveManager.LoadSetting(vsyncPref);
            textureQualityDropdown.Dropdown.value = SaveManager.LoadSetting(texturesQualityPref);

            // Controls.
            mouseSensitivity.value = 1f - SaveManager.LoadSettingF(mouseSensitivityPref);
            invertedMouse.currentValue = SaveManager.LoadSetting(invertedMousePref);

            // Gameplay.
            enableConsoleControl.currentValue = SaveManager.LoadSetting(enableConsolePref);
            subtitleControl.currentValue = SaveManager.LoadSetting(subtitlePref);
            enableCrosshairControl.currentValue = SaveManager.LoadSetting(crosshairPref);

            // Keyboards Keys.
            for (int i = 0; i < lookBindingKeyes.Length; i++)
                lookBindingKeyes[i].KeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode),
                    SaveManager.LoadSettingString(lookBindingKeyes[i].name, lookBindingKeyes[i].DefaultKey.ToString()));

            for (int i = 0; i < moveBindingKeyes.Length; i++)
                moveBindingKeyes[i].KeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode),
                    SaveManager.LoadSettingString(moveBindingKeyes[i].name, moveBindingKeyes[i].DefaultKey.ToString()));

            for (int i = 0; i < combatBindingKeyes.Length; i++)
                combatBindingKeyes[i].KeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode),
                    SaveManager.LoadSettingString(combatBindingKeyes[i].name, combatBindingKeyes[i].DefaultKey.ToString()));

            for (int i = 0; i < interactBindingKeyes.Length; i++)
                interactBindingKeyes[i].KeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode),
                    SaveManager.LoadSettingString(interactBindingKeyes[i].name, interactBindingKeyes[i].DefaultKey.ToString()));

            for (int i = 0; i < multiplayerBindingKeyes.Length; i++)
                multiplayerBindingKeyes[i].KeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode),
                    SaveManager.LoadSettingString(multiplayerBindingKeyes[i].name, multiplayerBindingKeyes[i].DefaultKey.ToString()));
        }

        public void SaveSettings()
        {
            // Sound.
            SaveManager.SaveSetting(musicPref, 1f - musicSlider.value);
            SaveManager.SaveSetting(sfxPref, 1f - sfxSlider.value);

            // Video.
            SaveManager.SaveSetting(fullscreenPref, fullscreenControl.currentValue);
            SaveManager.SaveSetting(resolutionPref, resolutionsDropdown.Dropdown.value);
            SaveManager.SaveSetting(qualityPref, qualityDropdown.Dropdown.value);
            SaveManager.SaveSetting(antialiasingPref, antiAliasingControl.currentValue);
            SaveManager.SaveSetting(shadowPref, shadowsControl.currentValue);
            SaveManager.SaveSetting(vsyncPref, vsyncControl.currentValue);
            SaveManager.SaveSetting(texturesQualityPref, textureQualityDropdown.Dropdown.value);

            // Controls.
            SaveManager.SaveSetting(mouseSensitivityPref, 1f - mouseSensitivity.value);
            SaveManager.SaveSetting(invertedMousePref, invertedMouse.currentValue);

            // Gameplay.
            SaveManager.SaveSetting(enableConsolePref, enableConsoleControl.currentValue);
            SaveManager.SaveSetting(subtitlePref, subtitleControl.currentValue);
            SaveManager.SaveSetting(crosshairPref, enableCrosshairControl.currentValue);

            // Keyboards Keys.
            for (int i = 0; i < lookBindingKeyes.Length; i++)
                SaveManager.SaveSetting(lookBindingKeyes[i].name, lookBindingKeyes[i].KeyCode.ToString());

            for (int i = 0; i < moveBindingKeyes.Length; i++)
                SaveManager.SaveSetting(moveBindingKeyes[i].name, moveBindingKeyes[i].KeyCode.ToString());

            for (int i = 0; i < combatBindingKeyes.Length; i++)
                SaveManager.SaveSetting(combatBindingKeyes[i].name, combatBindingKeyes[i].KeyCode.ToString());

            for (int i = 0; i < interactBindingKeyes.Length; i++)
                SaveManager.SaveSetting(interactBindingKeyes[i].name, interactBindingKeyes[i].KeyCode.ToString());

            for (int i = 0; i < multiplayerBindingKeyes.Length; i++)
                SaveManager.SaveSetting(multiplayerBindingKeyes[i].name, multiplayerBindingKeyes[i].KeyCode.ToString());


        }

        public void SetKeybindsToDefault()
        {
            for (int i = 0; i < lookBindingKeyes.Length; i++)
                lookBindingKeyes[i].SetToDefault();

            for (int i = 0; i < moveBindingKeyes.Length; i++)
                moveBindingKeyes[i].SetToDefault();

            for (int i = 0; i < combatBindingKeyes.Length; i++)
                combatBindingKeyes[i].SetToDefault();

            for (int i = 0; i < interactBindingKeyes.Length; i++)
                interactBindingKeyes[i].SetToDefault();

            for (int i = 0; i < multiplayerBindingKeyes.Length; i++)
                multiplayerBindingKeyes[i].SetToDefault();
        }

        public void UpdateAudioSlider()
        {
            PresistentAudioPlayer.instance.SetAudioVolume(1f - musicSlider.value, 1f - sfxSlider.value);
        }

        public void UpdateMouseSensitivitySlider()
        {
            // TODO: Change Mosue Sens value.
        }

        public void ReturnToMainMenu()
        {
            SceneLoader.LoadScene(SceneName.MainMenu);
        }

        public void ChangeWindow(int index)
        {
            for (int i = 0; i < panels.Length; i++)
                panels[i].SetActive(i == index);

            switch (index)
            {
                case 0:
                    titleTxt.text = "Video Settings";
                    break;
                case 1:
                    titleTxt.text = "Controls";
                    break;
                case 2:
                    titleTxt.text = "Sound Settings";
                    break;
                case 3:
                    titleTxt.text = "Game Options";
                    break;
                case 4:
                    break;
                default:
                    break;
            }

            LoadSettings();
        }

        public void ChangeControlsWindow(int index)
        {
            for (int i = 0; i < ControlOptionPanels.Length; i++)
                ControlOptionPanels[i].SetActive(i == index);
            switch (index)
            {
                case 0:
                    titleTxt.text = "Look";
                    break;
                case 1:
                    titleTxt.text = "Movement";
                    break;
                case 2:
                    titleTxt.text = "Combat";
                    break;
                case 3:
                    titleTxt.text = "Interactions";
                    break;
                case 4:
                    titleTxt.text = "Multiplayer & CO-OP";
                    break;
                default:
                    break;
            }

        }

        private void InitializeQuality()
        {
            qualityDropdown.Dropdown.ClearOptions();
            List<string> options = new List<string>();
            for (int i = 0; i < QualitySettings.names.Length; i++)
            {
                options.Add(QualitySettings.names[i]);
            }

            qualityDropdown.Dropdown.AddOptions(options);
            qualityDropdown.Dropdown.RefreshShownValue();
        }

        #region Setting
        public void InitializeResolution()
        {
            Resolution[] resolutions = Screen.resolutions;

            resolutionsDropdown.Dropdown.ClearOptions();
            List<string> options = new List<string>();
            int currentResIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width
                    && resolutions[i].height == Screen.currentResolution.height)
                    currentResIndex = i;
            }

            resolutionsDropdown.Dropdown.AddOptions(options);
            resolutionsDropdown.Dropdown.value = currentResIndex;
            resolutionsDropdown.Dropdown.RefreshShownValue();
        }

        public void SetResolution(int resIndex)
        {
            Resolution currentRes = resolutions[resIndex];
            Screen.SetResolution(currentRes.width, currentRes.height, Screen.fullScreen);
        }

        public void SetFullscreen(int isFullscreen)
        {
            Screen.fullScreen = isFullscreen == 0 ? false : true;
        }

        public void SetQuality(int qualityIndex)
        {
            if (qualityIndex != 6)
                QualitySettings.SetQualityLevel(qualityIndex);
            else
                switch (qualityIndex)
                {
                    case 0: // quality level - very low
                        textureQualityDropdown.Dropdown.value = 3;
                        antiAliasingControl.currentValue = 0;
                        break;
                    case 1: // quality level - low
                        textureQualityDropdown.Dropdown.value = 2;
                        antiAliasingControl.currentValue = 0;
                        break;
                    case 2: // quality level - medium
                        textureQualityDropdown.Dropdown.value = 1;
                        antiAliasingControl.currentValue = 0;
                        break;
                    case 3: // quality level - high
                        textureQualityDropdown.Dropdown.value = 0;
                        antiAliasingControl.currentValue = 0;
                        break;
                    case 4: // quality level - very high
                        textureQualityDropdown.Dropdown.value = 0;
                        antiAliasingControl.currentValue = 1;
                        break;
                    case 5: // quality level - ultra
                        textureQualityDropdown.Dropdown.value = 0;
                        antiAliasingControl.currentValue = 2;
                        break;
                }

            qualityDropdown.Dropdown.value = qualityIndex;
        }
        public void SetTextureQuality(int textureIndex)
        {
            QualitySettings.masterTextureLimit = textureIndex;
            textureQualityDropdown.Dropdown.value = textureIndex;
        }

        public void SetAntiAliasing()
        {
            QualitySettings.antiAliasing = antiAliasingControl.OnClick_Interact();
        }

        public void SetShadows()
        {
            QualitySettings.shadows = (ShadowQuality)shadowsControl.OnClick_Interact();
        }

        public void SetFullscreen()
        {
            Screen.fullScreen = fullscreenControl.OnClick_Interact() == 0 ? true : false;
        }

        public void SetInverted()
        {
            invertedMouse.OnClick_Interact();
        }

        public void SetVsync(int vSyncCount)
        {
            if (vSyncCount > 4) vSyncCount = 4;

            QualitySettings.vSyncCount = vSyncCount;
        }

        public void SetVsync01()
        {
            QualitySettings.vSyncCount = vsyncControl.OnClick_Interact();
        }

        public void SetConsole()
        {
            enableConsoleControl.OnClick_Interact();
        }

        public void SetSubtitle()
        {
            subtitleControl.OnClick_Interact();
        }
        public void SetCrosshair()
        {
            enableCrosshairControl.OnClick_Interact();
        }

        #endregion

        #region BindingKeys

        public void OnClick_CancelKeyBinding()
        {
            ToggleKeyboardBindingPhase(false);
        }

        public void OnClick_SetKey(int index)
        {
            ToggleKeyboardBindingPhase(true);
            currentkeyIndex = index;
        }

        public void OnClick_SetLookKey(int index)
        {
            OnClick_SetKey(index);
            currentkeyType = "look";
        }

        public void OnClick_SetMoveKey(int index)
        {
            OnClick_SetKey(index);
            currentkeyType = "move";
        }
        public void OnClick_SetCombatKey(int index)
        {
            OnClick_SetKey(index);
            currentkeyType = "combat";
        }
        public void OnClick_SetInteractKey(int index)
        {
            OnClick_SetKey(index);
            currentkeyType = "interact";
        }
        public void OnClick_SetMultiplayerKey(int index)
        {
            OnClick_SetKey(index);
            currentkeyType = "multiplayer";
        }

        private void ToggleKeyboardBindingPhase(bool value)
        {
            IsOnBindingKeyState = value;
            pressAnyKeyYouWantToApplyPanel.SetActive(value);
        }

        public void ResetToDefaults()
        {

        }

        #endregion
    }
}