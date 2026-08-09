using UnityEngine;

public class OwnedHeroesUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshOwnedHeroesUI();
        GameManager.Instance.OnGameLoaded += RefreshOwnedHeroesUI;
    }

    void OnDisable()
    {
        GameManager.Instance.OnGameLoaded -= RefreshOwnedHeroesUI;
    }

    private void RefreshOwnedHeroesUI()
    {
        ClearAllChildren();

        var gm = GameManager.Instance;
        var ownedHeroEquips = gm.heroManager.ownedHeroEquips;
        
        foreach (var ownedHeroEquip in ownedHeroEquips)
        {
            var originalHeroCard = gm.managerUI.TakeHeroCard(ownedHeroEquip.data.ID);
            var heroCard = Instantiate(originalHeroCard, transform);
        }
    }

    private void ClearAllChildren()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
