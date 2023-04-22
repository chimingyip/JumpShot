using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CooldownTimer : MonoBehaviour {
    public float cooldownAmount = 0.2f;
    public bool CooldownComplete => Time.time > m_cooldownCompleteTime;
    private float m_cooldownCompleteTime;

    public void StartCooldown() {
        m_cooldownCompleteTime = Time.time + cooldownAmount;
    }
}
