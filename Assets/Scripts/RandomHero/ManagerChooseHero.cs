using UnityEngine;

public class ManagerChooseHero : MonoBehaviour
{
    [SerializeField] private int day;
    [SerializeField] private ChooseHero[] chooseHeroes;
    [SerializeField] private HeroEquip[] results;

    private ManagerRecruitHero managerRecruitHero;
    private RandomHero randomHero;
    private void Awake()
    {
        randomHero = new RandomHero();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        managerRecruitHero = GameManager.Instance.managerRecruitHero;
        day = GameManager.Instance.survivalManager.TakeDay();
        if (managerRecruitHero.GetGeneratedDay() == day
            && managerRecruitHero.CheckChoose())
        {
            gameObject.SetActive(false);
            return;
        }
        else if (managerRecruitHero.GetGeneratedDay() != day)
        {
            results = randomHero.StartRandom(day);
            managerRecruitHero.SaveResultRandom(results, day);
        }
        else
        {
            results = managerRecruitHero.GetResultRandom();
        }
        ShowChooseHero(results);
    }

    private void ShowChooseHero(HeroEquip[] heroEquips)
    {
        for(int i = 0; i < heroEquips.Length; i++)
        {
            int ID = heroEquips[i].data.ID;
            chooseHeroes[i].UpdateCharacterEquip(heroEquips[i]);
            GameObject heroCard = Instantiate(GameManager.Instance.managerUI.TakeHeroCard(ID), chooseHeroes[i].transform);

            RectTransform rect = heroCard.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localScale = new Vector3(2.5f, 4, 1);
        }
    }
}
