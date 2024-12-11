using UnityEngine;
using Yarn.Unity;

public class BackgroundManager : MonoBehaviour
{
    // Reference to the background SpriteRenderer
    public SpriteRenderer backgroundRenderer;

    // Reference to the character SpriteRenderer
    public SpriteRenderer characterRenderer;

    // Arrays to hold the background and character sprites
    public Sprite[] backgroundSprites;
    public Sprite[] characterSprites;

    // Command to change the background image
    [YarnCommand("change_background")]
    public void ChangeBackground(string backgroundName)
    {
        foreach (var sprite in backgroundSprites)
        {
            if (sprite.name == backgroundName)
            {
                backgroundRenderer.sprite = sprite;
                Debug.Log($"Background changed to: {backgroundName}");
                return;
            }
        }

        Debug.LogError($"Background '{backgroundName}' not found in the backgroundSprites array.");
    }

    // Command to change the character sprite
    [YarnCommand("change_character")]
    public void ChangeCharacter(string characterName)
    {
        foreach (var sprite in characterSprites)
        {
            if (sprite.name == characterName)
            {
                characterRenderer.sprite = sprite;
                Debug.Log($"Character changed to: {characterName}");
                return;
            }
        }

        Debug.LogError($"Character '{characterName}' not found in the characterSprites array.");
    }
}