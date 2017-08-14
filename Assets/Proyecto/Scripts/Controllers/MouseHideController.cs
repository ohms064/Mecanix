using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHideController : MonoBehaviour {
    private bool m_cursorIsLocked;

    private void InternalLockUpdate() {
        if ( Input.GetKeyUp( KeyCode.Escape ) ) {
            m_cursorIsLocked = false;
        }
        else if ( Input.GetMouseButtonUp( 0 ) ) {
            m_cursorIsLocked = true;
        }

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

    private void Start() {
        m_cursorIsLocked = true;
    }
}
