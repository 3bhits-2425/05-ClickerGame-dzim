using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickingToScore : MonoBehaviour
{
    public TMP_Text button_text;
    public TMP_Text score_text;
    public TMP_Text upgrade_text;

    private int score = 0;
    private int nextUpgradeAt = 20;
    private bool upgradeAvailable = false;

    private bool upgradeActive = false;
    private int clickValue = 1;
    private int baseClickValue = 1;
    private int upgradeBonus = 5;

    void Start()
    {
        button_text.text = "Click to Score";
        upgrade_text.text = ""; // leeres Textfeld
        UpdateScoreText();
    }

    public void Score()
    {
        score += clickValue;

        if (upgradeActive && clickValue > 1)
        {
            clickValue -= 1;
        }

        if (!upgradeAvailable && score >= nextUpgradeAt)
        {
            upgradeAvailable = true;
            upgrade_text.text = $"Upgrade verfügbar! Drücke 'U' um es für 10 Punkte zu kaufen.";
        }

        UpdateScoreText();
    }

    void Update()
    {
        if (upgradeAvailable && Input.GetKeyDown(KeyCode.U))
        {
            TryUpgrade();
        }
    }

    void TryUpgrade()
    {
        if (score >= 10)
        {
            score -= 10;
            upgradeAvailable = false;
            upgradeActive = true;

            baseClickValue += upgradeBonus;
            clickValue = baseClickValue;

            nextUpgradeAt += 20;

            upgrade_text.text = $"Upgrade aktiviert! Klickwert = {clickValue}";
            UpdateScoreText();
        }
        else
        {
            upgrade_text.text = "Nicht genug Punkte für Upgrade!";
        }
    }

    void UpdateScoreText()
    {
        score_text.text = $"Score = {score}";
    }
}
