using UnityEngine;

namespace DaleranGames.UI
{
    public class ManualTooltip : BaseGameObjectTooltip
    {
#pragma warning disable 0649
        [SerializeField]
        [TextArea(3, 8)]
        string text;
        public override string Info { get { return text; } }
#pragma warning restore 0649
    }
}
