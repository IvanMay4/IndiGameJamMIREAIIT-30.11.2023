using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Settings{
    public static float volume = 1;
    public static bool isEnterSettings = false;
    public static bool isLoadGame = false;
    public static string filenameSaveGame = "Game.save";
    public static string filenameSaveSettings = "Settings.save";

    public static void OpenMainMenu() => SceneManager.LoadScene("MainMenu");

    public static void OpenSettings() => SceneManager.LoadScene("Settings");

    public static void OpenGame() => SceneManager.LoadScene("Game");

    public static void OpenWin() => SceneManager.LoadScene("Win");

    public static void OpenGameOver() => SceneManager.LoadScene("GameOver");

    public static void Exit() => Application.Quit();

    public static void DeleteFile(string filename) => new FileInfo(@$"{filename}").Delete();

    public static void ButtonSetEnabled(Button button){
        if (!button.enabled)
            button.GetComponent<Image>().color = Color.grey;
    }
}
