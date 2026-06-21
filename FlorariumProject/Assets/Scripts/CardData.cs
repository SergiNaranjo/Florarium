using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Florarium/Card Data")]
public class CardData : ScriptableObject
{
    [Header("Identidad")]
    public string cardName;
    public Season season;
    public Sprite artwork;

    [Header("Valores")]
    public int baseValue;
    public int marketCost;

    [Header("Habilidad")]
    public AbilityTrigger trigger;
    public CardAbilityType abilityType;

    [TextArea]
    public string abilityDescription;

    private void OnValidate()
    {
        marketCost = baseValue * 2;
    }
}
