using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features
{
    public class LookAround :  MonoBehaviour, IActivable, IFeatureSetup, IFeatureAction //Other channels
    {
        //Configuration
        [Header("Settings")]
        public Settings settings;
        //Control
        [Header("Control")]
        [SerializeField] private bool active;
        //States
        [Header("States")]
        [SerializeField] private Vector2 rotation;
        //Properties
        [Header("Properties")]
        [SerializeField] private Vector2 sensibility;
        //References
        //Componentes
        [Header("Components")]
        [SerializeField] private Transform orientation;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void SetupFeature(Controller controller)
        {
            settings = controller.settings;

            //Setup Properties

            ToggleActive(true);
        }

        public void FeatureAction(Controller controller, params Setting[] setting){
            if (!active) return;

            if (setting.Length < 1) return;

            Vector2 mouseDelta = setting[0].vector2Value;

            rotation.x = Mathf.Clamp(rotation.x, 0f, 1f);

        }

        public bool GetActive()
        {
            return active;
        }

        public void ToggleActive(bool active)
        {
            this.active = active;
        }
    }
}
