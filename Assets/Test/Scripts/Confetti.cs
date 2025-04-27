using System.Collections.Generic;
using AxGrid.Base;
using AxGrid.Model;
using Coffee.UIExtensions;
using UnityEngine;

namespace Scripts
{
    public class Confetti : MonoBehaviourExtBind
    {
        [SerializeField] private List<UIParticle> confetti;

        [Bind(FSMNames.States.OnResultStateEnter)]
        private void PlayConfetti()
        {
            confetti.ForEach(c => c.Play());
        }
    }
}