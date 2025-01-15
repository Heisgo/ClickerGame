using System.IO;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;

public class PunchsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] TextMeshProUGUI punchesText;
    [Header("Data")]
    [SerializeField] double punches;
    [SerializeField] double punchIncrement;

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        LoadData();
        InputManager.onPunched += CarrotClickCallback;
    }
    private void OnDestroy() => InputManager.onPunched -= CarrotClickCallback;
    void CarrotClickCallback()
    {
        punches += punchIncrement;
        SaveData();
        UpdateUI();
    }
    void SaveData()
    {
        GameData data = new() { punches = punches };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }
    void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            punches = data.punches;
        }
        else
            punches = 0;

        UpdateUI();
    }
    void UpdateUI()
    {
        punchesText.text = $"{NumberFormatter.FormatNumber(punches)}";
    }
}

[System.Serializable]
public class GameData
{
    public double punches;
}
