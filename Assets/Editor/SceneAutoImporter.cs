using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class SceneAutoImporter
{
    static SceneAutoImporter()
    {
        // Este método se ejecutará cada vez que se importen assets
        EditorApplication.delayCall += AddScenesToBuildSettings;
    }

    private static void AddScenesToBuildSettings()
    {
        // Busca todas las escenas en la carpeta "Assets/Scenes"
        string[] scenePaths = Directory.GetFiles("Assets/Scenes", "*.unity", SearchOption.AllDirectories);

        EditorBuildSettingsScene[] buildScenes = new EditorBuildSettingsScene[scenePaths.Length];

        for (int i = 0; i < scenePaths.Length; i++)
        {
            buildScenes[i] = new EditorBuildSettingsScene(scenePaths[i], true);
        }

        // Actualiza las escenas en Build Settings
        EditorBuildSettings.scenes = buildScenes;
        Debug.Log("Escenas agregadas automáticamente a Build Settings.");
    }
}
