using UnityEngine;

[System.Serializable]
public class NoteData
{
    public KeyCode keycode;
    public float time;
    public float speedScale;

    public NoteData(KeyCode keycode, float time, float speedScale)
    {
        this.keycode = keycode;
        this.time = time;
        this.speedScale = speedScale;
    }
}
