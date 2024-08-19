using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_main_menu : MonoBehaviour
{
    // Botones
    [SerializeField] private Button play_button;
    [SerializeField] private Button settings_button;
    [SerializeField] private Button credits_button;
    [SerializeField] private Button exit_button;
    // Botones de back
    [SerializeField] private Button back_settings_button;
    [SerializeField] private Button back_credits_button;
    // Slider
    [SerializeField] private Slider slider_player_1;
    [SerializeField] private Slider slider_player_2;
    // Paneles 
    [SerializeField] private GameObject settings_panel;
    [SerializeField] private GameObject main_panel;
    [SerializeField] private GameObject pause_panel;
    [SerializeField] private GameObject credits_panel;
    // Players
    [SerializeField] private Movement player_1;
    [SerializeField] private Movement player_2;
    // Texto 
    [SerializeField] private TextMeshProUGUI velocidad_player_1;
    [SerializeField] private TextMeshProUGUI velocidad_player_2;

    private void Awake()
    {

        // Botón play
        play_button.onClick.AddListener(on_play_button_clicked);
        // Botón settings
        settings_button.onClick.AddListener(on_settings_button_clicked);
        // Botón credits
        credits_button.onClick.AddListener(on_credits_button_clicked);
        // Boton Exit
        exit_button.onClick.AddListener(on_exit_button_clicked);
        // Botón back settings
        back_settings_button.onClick.AddListener(on_back_settings_button_clicked);
        // Botón back credits
        back_credits_button.onClick.AddListener(on_back_credits_button_clicked);
        // Slider
        slider_player_1.onValueChanged.AddListener(on_speed_player_1_changed);
        slider_player_2.onValueChanged.AddListener(on_speed_player_2_changed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause_panel.activeSelf)
            {
                pause_panel.SetActive(true);
            }
        }



    }

    private void on_play_button_clicked()
    {
        if (pause_panel != null)
        {
            pause_panel.SetActive(false);
        }
    }

    private void on_settings_button_clicked()
    {
        if (pause_panel != null)
        {
            main_panel.SetActive(false);
            settings_panel.SetActive(true);
        }
    }

    private void on_credits_button_clicked()
    {
        if (pause_panel != null)
        {
            main_panel.SetActive(false);
            credits_panel.SetActive(true);
        }
    }

    private void on_exit_button_clicked()
    {
        if (pause_panel != null)
        {
            Application.Quit();
            Debug.Log("Game is quitting...");
        }
    }

    private void on_back_settings_button_clicked()
    {
        if (pause_panel != null)
        {
            settings_panel.SetActive(false);
            main_panel.SetActive(true);
        }
    }

    private void on_back_credits_button_clicked()
    {
        if (pause_panel != null)
        {
            credits_panel.SetActive(false);
            main_panel.SetActive(true);
        }
    }

    private void on_speed_player_1_changed(float speed)
    {

        velocidad_player_1.text = slider_player_1.value.ToString("F2");

        player_1.set_speed(speed);

        // Implementar lógica para manejar el cambio de velocidad
        Debug.Log("Speed changed to: " + speed);
    }
    private void on_speed_player_2_changed(float speed)
    {

        velocidad_player_2.text = slider_player_2.value.ToString("F2");

        player_2.set_speed(speed);

        // Implementar lógica para manejar el cambio de velocidad
        Debug.Log("Speed changed to: " + speed);
    }
}
