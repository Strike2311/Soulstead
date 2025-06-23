using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PerkManager : MonoBehaviour
{
    public GameObject perkPanel;
    public Transform perkContainer;
    public GameObject[] perkButtons;

    public List<Perk> allPerks;
    private GameObject player;

    public PlayerStatsData stats;
    private PlayerXP playerXP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerXP = player.GetComponent<PlayerXP>();
        perkPanel.SetActive(false);
        if (playerXP != null)
            playerXP.OnLevelUp += ShowPerkChoices;
    }

    public void ShowPerkChoices()
    {
        Time.timeScale = 0f; // Pause game
        perkPanel.SetActive(true);

        var chosenPerks = GetRandomPerks(3);
        int counter = 0;

        foreach (Perk perk in chosenPerks)
        {
            GameObject btn = Instantiate(perkButtons[counter], perkContainer);
            counter++;
            Transform nameText = btn.transform.Find("PerkTitle");
            Transform descText = btn.transform.Find("PerkDescription");
            nameText.GetComponent<TMP_Text>().text = perk.perkName;

            descText.GetComponent<TMP_Text>().text = perk.description;
            btn.transform.Find("PerkImage").GetComponent<Image>().sprite = perk.icon;

            btn.GetComponent<Button>().onClick.AddListener(() => SelectPerk(perk));
        }
    }

    void SelectPerk(Perk perk)
    {
        Debug.Log("Click");
        perk.Apply(stats);
        perkPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    List<Perk> GetRandomPerks(int count)
    {
        List<Perk> result = new List<Perk>();
        List<Perk> copy = new List<Perk>(allPerks);
        for (int i = 0; i < count && copy.Count > 0; i++)
        {
            int index = Random.Range(0, copy.Count);
            result.Add(copy[index]);
            copy.RemoveAt(index);
        }
        return result;
    }
}
