using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationManagement : MonoBehaviour
{
    public Animator[] animators;
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "CharacterCustomization")
        {
            foreach (Animator animator in animators)
            {
                animator.enabled = false;
            }
        }

        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene current)
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.enabled = true;
            }
        }
    }
}
