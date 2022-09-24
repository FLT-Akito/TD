using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    [SerializeField]  string summonName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int at;
    [SerializeField] int spAt;

    [SerializeField] Sprite spriteSummon;

    public int Attack { get => at; }
    public int SpAt { get => spAt;}
    public string Name { get => summonName; }
    public string Description { get => description; }
    public Sprite SummonSprite { get => spriteSummon; }
}
