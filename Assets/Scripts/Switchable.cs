using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Switchable {
    void turnOnOff(bool isOn);
    bool isRunning();
}
