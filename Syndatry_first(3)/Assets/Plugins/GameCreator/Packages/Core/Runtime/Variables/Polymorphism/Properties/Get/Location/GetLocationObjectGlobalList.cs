using System;
using UnityEngine;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
    [Title("Game Object Global List Variable")]
    [Category("Variables/Game Object Global List Variable")]
    
    [Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
    [Description("Returns the Game Object value of a Global List Variable")]

    [Serializable] [HideLabelsInEditor]
    public class GetLocationObjectGlobalList : PropertyTypeGetLocation
    {
        [SerializeField]
        protected FieldGetGlobalList m_Variable = new FieldGetGlobalList(ValueGameObject.TYPE_ID);

        [SerializeField] private bool m_Rotate = true;
        
        public override Location Get(Args args)
        {
            return new Location(this.m_Variable.Get<GameObject>(), Vector3.zero, this.m_Rotate);
        }

        public override Location Get(GameObject gameObject)
        {
            return new Location(this.m_Variable.Get<GameObject>(), Vector3.zero, this.m_Rotate);
        }

        public override string String => this.m_Variable.ToString();
    }
}