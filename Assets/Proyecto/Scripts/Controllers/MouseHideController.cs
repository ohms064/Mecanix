using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHideController : MonoBehaviour {
#if !UNITY_ANDROID || UNITY_EDITOR
    public bool m_cursorIsLocked = true;

    private void InternalLockUpdate() {
#if UNITY_EDITOR
        if ( Input.GetKeyUp( KeyCode.Escape ) ) {
            m_cursorIsLocked = false;
        }
        else if( Input.GetMouseButtonUp( 0 ) ) {
            m_cursorIsLocked = true;
        }
#endif

        if ( m_cursorIsLocked ) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if ( !m_cursorIsLocked ) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Update() {
        InternalLockUpdate();
    }

#endif
}
