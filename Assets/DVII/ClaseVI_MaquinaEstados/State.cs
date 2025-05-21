using UnityEngine;

namespace DVII.ClaseVI_MaquinaEstados
{
    public abstract class State : MonoBehaviour
    {
        protected FSM_Controller controller;

        public virtual void OnEnterState(FSM_Controller controller)
        {
            this.controller = controller;
        }

        public abstract void OnUpdateState();
    
        public abstract void OnExitState();

    }
}
