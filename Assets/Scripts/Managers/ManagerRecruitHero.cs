using UnityEngine;

public class ManagerRecruitHero : MonoBehaviour
{
    [SerializeField] private bool isChoose;
    [SerializeField] private int generatedDay;
    [SerializeField] private HeroEquip[] results;

    private void Awake()
    {
        results = new HeroEquip[3];
        generatedDay = 0;
    }

    public void SaveResultRandom(HeroEquip[] heroes, int dayUpdate)
    {
        for(int i = 0; i < results.Length; i++)
        {
            results[i] = heroes[i];
        }
        generatedDay = dayUpdate;
        isChoose = false;
    }
    
    public HeroEquip[] GetResultRandom()
    {
        return results;
    }

    public int GetGeneratedDay()
    {
        return generatedDay;
    }

    public bool CheckChoose()
    {
        return isChoose;
    }

    public void FinishChoose()
    {
        isChoose = true;
    }
}
