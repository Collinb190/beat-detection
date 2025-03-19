# Beat Detection System for Unity

## Overview
This project is a Unity-based beat detection system that synchronizes gameplay elements with audio. It detects beats from an audio source and triggers visual or gameplay effects accordingly.

## Features
- Synchronizes UnityEvents with beats in an audio track.
- Adjustable beat magnification to modify event timing.
- Works dynamically with any **AudioSource** and clip.

## Getting Started
### Prerequisites
- Unity 2021.3+ (or compatible version)
- AudioSource with an assigned audio clip
- UnityEvents to trigger beat-based actions

### Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/yourusername/beat-detection-system.git
   ```
2. Open the project in Unity.
3. Attach the `BeatManager` script to a GameObject with an `AudioSource`.
4. Assign an audio clip to the `AudioSource`.
5. Configure detection settings in the Unity Inspector.
6. Configure the `BPM` value to match your music.
7. Add and configure beats in the `Beats` array, attaching UnityEvents to execute actions on beat.

## Code Overview
### `BeatManager.cs`
```csharp
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Beats[] _beats;

    private void Update()
    {
        foreach (Beats beat in _beats)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * beat.GetBeatLength(_bpm)));
            beat.CheckForNewBeat(sampledTime);
        }
    }
}
```

### `Beats.cs`
```csharp
[System.Serializable]
public class Beats
{
    [SerializeField] private float _magnifier; // 1 = normal speed, 0.5 = half speed, 2 = double speed
    [SerializeField] private UnityEvent _trigger;
    private int _lastBeat;

    public float GetBeatLength(float bpm)
    {
        return 60f / (bpm * _magnifier);
    }

    public void CheckForNewBeat(float currentBeat)
    {
        if (Mathf.FloorToInt(currentBeat) != _lastBeat)
        {
            _lastBeat = Mathf.FloorToInt(currentBeat);
            _trigger.Invoke();
        }
    }
}
```

## Usage
1. Attach the `BeatManager` script to a GameObject.
2. Assign an **AudioSource** and an audio clip.
3. Set the **BPM** of your track.
4. Add beat patterns using the **Beats** array.
5. Link UnityEvents to trigger animations, effects, or actions on the beat.

## Troubleshooting
- **Events are not triggering**: Ensure `_bpm` is correctly set, and `_magnifier` is properly adjusted.
- **Timing is off**: Check the frequency of the audio clip and verify that the `AudioSource` is playing.

## Future Improvements
- Add support for dynamically adjusting BPM.
- Implement visual debugging for beat synchronization.

## License
This project is licensed under the MIT License.
