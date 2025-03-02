using System;
using UnityEngine.Events;

namespace UnityEngine.Localization.Components
{
    [Serializable]
    public class UnityEventSprite : UnityEvent<Sprite> {}

    [AddComponentMenu("Localization/Asset/Localize Sprite Event")]
    public class LocalizeSpriteEvent : LocalizedAssetEvent<Sprite, LocalizedSprite, UnityEventSprite>
    {
    }

}
