using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

	public float shakeAmount = 0.3f;	
	float shakeTime = 0.0f;
	Vector3 initialPosition;

	void Start()
    {
		initialPosition = this.transform.position;
	}

    /// <summary>화면 흔들기</summary>    
    public void Shake(float m_duration, float m_shakeAmount)
    {		
		shakeTime = m_duration;
        shakeAmount = m_shakeAmount;
    }

    void Update () {
		#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.Space)) Shake(1f, 0.3f);
		#endif

		if (shakeTime > 0){
			this.transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
			shakeTime -= Time.deltaTime;
		}
		else{
			shakeTime = 0.0f;
			this.transform.position = initialPosition;
		}
	}
}
