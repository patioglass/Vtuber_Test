using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;

public class ViveHaptic : MonoBehaviour
{
    public SteamVR_Action_Boolean _action = SteamVR_Actions.default_InteractUI;
    public SteamVR_Action_Vibration _haptic = SteamVR_Actions.default_Haptic;
    public SteamVR_Input_Sources _handType;
    private const float DEFAULT_HAPTIC_SECONDS = 10.0f;

    void Start()
    {
        // アタッチしたコントローラのinputSourceを取得
        _handType = this.gameObject.GetComponent<SteamVR_Behaviour_Pose>().inputSource;
    }
 
    void Update()
    {
        // コントローラの入力で振動
        if (_action.GetLastStateDown(_handType))
        {
            _haptic.Execute(0, DEFAULT_HAPTIC_SECONDS, 1f / DEFAULT_HAPTIC_SECONDS, 1, _handType);
        }
    }
}
