using UnityEngine;
using ColossalFramework;
using ColossalFramework.UI;
using ICities;

namespace MoreSimulationSpeedOptions2
{
    public class Mod : LoadingExtensionBase, IUserMod
    {
        internal static UIButton speedButton;

        public string Name => "More Simulation Speed Options 2";
        public string Description => "Adds more simulation speed options.";

        public override void OnLevelLoaded(LoadMode mode)
        {
        	new GameObject().AddComponent<Initializer>();
        }
         
        public override void OnLevelUnloading()
        {
        	Object.Destroy(speedButton.gameObject);
        }

        unsafe internal static void OnMouseUp(UIComponent c, UIMouseEventParameter p)
        {
            int speed = Singleton<SimulationManager>.instance.SelectedSimulationSpeed;
            Color32 textColor = new Color32(0, 0, 0, 255);

            if ((p.buttons & UIMouseButton.Left) != 0)
            {
                switch (speed)
                {
                    case 1: speed = 2; textColor.r = 87;  textColor.g = 165; break;
                    case 2: speed = 4; textColor.r = 245; textColor.g = 216; break;
                    case 3:
                    case 4: speed = 6; textColor.r = 255; textColor.g = 130; break;
                    case 6: speed = 9; textColor.r = 255; textColor.g = 0;   break;
                    case 9: speed = 1; textColor.r = 0;   textColor.g = 255; break;
                }
            }
            else if ((p.buttons & UIMouseButton.Right) != 0)
            {
                switch (speed)
                {
                    case 1: speed = 9; textColor.r = 255; textColor.g = 0;   break;
                    case 2: speed = 1; textColor.r = 0;   textColor.g = 255; break;
                    case 3:
                    case 4: speed = 2; textColor.r = 87;  textColor.g = 165; break;
                    case 6: speed = 4; textColor.r = 245; textColor.g = 216; break;
                    case 9: speed = 6; textColor.r = 255; textColor.g = 130; break;
                }
            }
            else
            {
                return;
            }

            Singleton<SimulationManager>.instance.SelectedSimulationSpeed = speed;

            char* text = stackalloc char[]
            {
                'X',
                (char)('0' + speed)
            };
            speedButton.text = new string(text, 0, 2);

            speedButton.textColor = textColor;
            speedButton.focusedTextColor = textColor;
            speedButton.hoveredTextColor = textColor;
            speedButton.pressedTextColor = textColor;
        }
    }
}
