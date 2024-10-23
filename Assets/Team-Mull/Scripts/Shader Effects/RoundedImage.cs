using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RoundedImage : MonoBehaviour
{
    public float CornerRadius = 0.2f;

    [SerializeField] private Material roundedMaterial;

    private void Start()
    {
        Image image = GetComponent<Image>();    
        if(image != null && image.sprite != null )
        {
             roundedMaterial.SetTexture("_MainTex", image.sprite.texture);
            roundedMaterial.SetFloat("_CornerRadius", CornerRadius);
            image.material = roundedMaterial;
        }
    }

}
