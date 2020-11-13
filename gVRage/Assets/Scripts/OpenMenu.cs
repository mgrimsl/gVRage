using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour {

  void OnMouseDown() {
    CorkBoardMenu.GameIsPaused = true;
  }
}
