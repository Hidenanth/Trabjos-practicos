using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_main_menu : MonoBehaviour
{
    // Botones
    [Header("buttons main menu")]
    [SerializeField] private Button play_button;
    [SerializeField] private Button settings_button;
    [SerializeField] private Button credits_button;
    [SerializeField] private Button exit_button;

    [Header("buttons Main Menu settings")]
    [SerializeField] private Button velocity_button;
    [SerializeField] private Button paleta_button;
    [SerializeField] private Button rgb_button;
    [SerializeField] private Button back_button_menu_setiings;

    [Header("button back Main Menu settings")]
    [SerializeField] private Button back_settings_button;

    [Header("Velocity")]

    [Header("Slider velocity")]
    [SerializeField] private Slider slider_player_1;
    [SerializeField] private Slider slider_player_2;

    [Header("button back velocity")]
    [SerializeField] private Button back_settings_button_velocity;

    [Header("Paleta")]

    [Header("Slider paleta")]
    [SerializeField] private Slider slider_paleta_player_1;
    [SerializeField] private Slider slider_paleta_player_2;

    [Header("button back paleta")]
    [SerializeField] private Button back_settings_button_paleta;

    [Header("buttons select RGB")]
    [SerializeField] private Button player_1_button;
    [SerializeField] private Button player_2_button;

    [Header("buttons back select RGB")]
    [SerializeField] private Button back_rgb_button;

    [Header("Slider RGB player 1")]
    [SerializeField] private Slider slider_player_1_R;
    [SerializeField] private Slider slider_player_1_G;
    [SerializeField] private Slider slider_player_1_B;
    
    [Header("Slider RGB player 2")]
    [SerializeField] private Slider slider_player_2_R;
    [SerializeField] private Slider slider_player_2_G;
    [SerializeField] private Slider slider_player_2_B;

    [Header("Button back credits")]
    [SerializeField] private Button back_credits_button;
    // Paneles 
    [Header("Paneles")]
    [SerializeField] private GameObject settings_panel;
    [SerializeField] private GameObject settings_panel_main;
    [SerializeField] private GameObject main_panel;
    [SerializeField] private GameObject pause_panel;
    [SerializeField] private GameObject credits_panel;

    [Header("Paneles main menu settings")]
    [SerializeField] private GameObject settings_panel_velocity;
    [SerializeField] private GameObject settings_panel_paleta;
    [SerializeField] private GameObject settings_panel_RGB;

    [Header("Paneles Select Player RGB")]
    [SerializeField] private GameObject rgb_panel_player_1;
    [SerializeField] private GameObject rgb_panel_player_2;
    [SerializeField] private Button back_rgb_panel_player_1;
    [SerializeField] private Button back_rgb_panel_player_2;

    // Players
    [Header("Players")]
    [SerializeField] private Movement player_1;
    [SerializeField] private Movement player_2;

    // Texto 
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI velocidad_player_1;
    [SerializeField] private TextMeshProUGUI velocidad_player_2;
    [SerializeField] private GameObject presione_space;
    [SerializeField] private TextMeshProUGUI points_player_1; 
    [SerializeField] private TextMeshProUGUI points_player_2; 

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        //buttones select player RGB 
        player_1_button.onClick.AddListener(on_player_1_button_clicked);
        player_2_button.onClick.AddListener(on_player_2_button_clicked);
        back_rgb_button.onClick.AddListener(on_back_rgb_button_clicked);
        back_rgb_panel_player_1.onClick.AddListener(on_back_rgb_panel_player_1_clicked);
        back_rgb_panel_player_2.onClick.AddListener(on_back_rgb_panel_player_2_clicked);
        //settings main menu
        velocity_button.onClick.AddListener(on_velocity_button_clicked);
        paleta_button.onClick.AddListener(on_paleta_button_clicked);
        rgb_button.onClick.AddListener(on_rgb_button_clicked);
        back_button_menu_setiings.onClick.AddListener(on_back_button_menu_setiings_clicked);
        back_settings_button_velocity.onClick.AddListener(on_back_settings_button_velocity_clicked);
        back_settings_button_paleta.onClick.AddListener(on_back_settings_button_paleta_clicked);
        //
        play_button.onClick.AddListener(on_play_button_clicked);
        settings_button.onClick.AddListener(on_settings_button_clicked);
        credits_button.onClick.AddListener(on_credits_button_clicked);
        exit_button.onClick.AddListener(on_exit_button_clicked);
        back_settings_button.onClick.AddListener(on_back_settings_button_clicked);
        back_credits_button.onClick.AddListener(on_back_credits_button_clicked);
        
        slider_player_1.onValueChanged.AddListener(on_speed_player_1_changed);
        slider_player_2.onValueChanged.AddListener(on_speed_player_2_changed);

        velocidad_player_1.text = slider_player_1.value.ToString("F2");
        velocidad_player_2.text = slider_player_2.value.ToString("F2");
    }

    private void Update()
    {
        points_player_1.text = gameManager.points_player_1.ToString();
        points_player_2.text = gameManager.points_player_2.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_panel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        pause_panel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        credits_panel.SetActive(false);
        settings_panel.SetActive(false);
        main_panel.SetActive(true);
        pause_panel.SetActive(false);
        Time.timeScale = 1;
    }

    private void on_play_button_clicked()
    {
        ResumeGame();
    }

    private void on_settings_button_clicked()
    {
        main_panel.SetActive(false);
        settings_panel.SetActive(true);
    }

    private void on_credits_button_clicked()
    {
        main_panel.SetActive(false);
        credits_panel.SetActive(true);
    }

    private void on_exit_button_clicked()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void on_back_settings_button_clicked()
    {
        settings_panel.SetActive(false);
        main_panel.SetActive(true);
    }

    /// Settings main menu

    private void on_velocity_button_clicked()
    {
        settings_panel_main.SetActive(false);
        settings_panel_velocity.SetActive(true);
    }
    private void on_paleta_button_clicked()
    {
        settings_panel_main.SetActive(false);
        settings_panel_paleta.SetActive(true);
    }
    private void on_rgb_button_clicked()
    {
        settings_panel_main.SetActive(false);
        settings_panel_RGB.SetActive(true);
    }
    private void on_back_button_menu_setiings_clicked()
    {
        settings_panel.SetActive(false);
        main_panel.SetActive(true);
    }

    // back buttons
    private void on_back_settings_button_velocity_clicked()
    {
        settings_panel_velocity.SetActive(false);
        settings_panel_main.SetActive(true);
        
    }
     private void on_back_settings_button_paleta_clicked()
    {
        settings_panel_paleta.SetActive(false);
        settings_panel_main.SetActive(true);
        
    }

    /// ///////////////////////////////////////////////

    /// <Paneles de RGB players>
    private void on_player_1_button_clicked()
    {
        settings_panel_RGB.SetActive(false);
        rgb_panel_player_1.SetActive(true);
        
    }
    private void on_player_2_button_clicked()
    {
        settings_panel_RGB.SetActive(false);
        rgb_panel_player_2.SetActive(true);
        
    }
    private void on_back_rgb_button_clicked()
    {
        settings_panel_RGB.SetActive(false);
        settings_panel_main.SetActive(true);
        
    }
     private void on_back_rgb_panel_player_1_clicked()
    {
        rgb_panel_player_1.SetActive(false);
        settings_panel_RGB.SetActive(true);
        
    }
    private void on_back_rgb_panel_player_2_clicked()
    {
        rgb_panel_player_2.SetActive(false);
        settings_panel_RGB.SetActive(true);
        
    }
    /// <Paneles de RGB players>

    private void on_back_credits_button_clicked()
    {
        credits_panel.SetActive(false);
        main_panel.SetActive(true);
    }

    private void on_speed_player_1_changed(float speed)
    {
        velocidad_player_1.text = slider_player_1.value.ToString("F2");
        player_1.set_speed(speed);
        Debug.Log("Speed changed to: " + speed);
    }

    private void on_speed_player_2_changed(float speed)
    {
        velocidad_player_2.text = slider_player_2.value.ToString("F2");
        player_2.set_speed(speed);
        Debug.Log("Speed changed to: " + speed);
    }

    public void inicio_game()
    {
        presione_space.SetActive(false);
    }

    public void reset_game()
    {
        presione_space.SetActive(true);
    }
}
