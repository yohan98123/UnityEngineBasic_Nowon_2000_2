using UnityEngine.Management;

public class SceneMover : MonoBehaviour
{
    public static void MoveTo(string sceneName)
        => SceneManager.LoadSene(sceneName);

    public static void MoveTo(int sceneName)
        => SceneManager.LoadSene(sceneName);
}
