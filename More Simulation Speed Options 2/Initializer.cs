using UnityEngine;
using ColossalFramework.UI;

namespace MoreSimulationSpeedOptions2
{
    public class Initializer : MonoBehaviour
    {
        private void Start()
        {
            UIMultiStateButton speedBar = UIView.GetAView().FindUIComponent<UIMultiStateButton>("Speed");
            GameObject go = new GameObject();
            go.transform.parent = speedBar.transform.parent.transform;
            UIButton speedButton = go.AddComponent<UIButton>();
            
            speedButton.width = speedBar.width;
            speedButton.height = speedBar.height;
            speedButton.transformPosition = speedBar.transformPosition;
            speedButton.transform.position = speedBar.transform.position;

            speedBar.enabled = false;

            Color32 textColor = new Color32(0, 255, 0, 255);
                
            speedButton.text = "x1";
            speedButton.textColor = textColor;
            speedButton.focusedTextColor = textColor;
            speedButton.hoveredTextColor = textColor;
            speedButton.pressedTextColor = textColor;

            speedButton.normalBgSprite = "ButtonMenu";
            speedButton.disabledBgSprite = "ButtonMenuDisabled";
            speedButton.hoveredBgSprite = "ButtonMenuHovered";
            speedButton.focusedBgSprite = "ButtonMenu";
            speedButton.pressedBgSprite = "ButtonMenuPressed";

            speedButton.playAudioEvents = true;

            speedButton.eventMouseUp += Mod.OnMouseUp;

            Mod.speedButton = speedButton;

            Destroy(this.gameObject);
        }
    }
}
