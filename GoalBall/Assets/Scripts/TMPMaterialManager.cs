using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPMaterialManager : MonoBehaviour
{
    TextMeshProUGUI TMP;
    [SerializeField] float Sfotness;
    [SerializeField] float Dilate;
    [SerializeField] Color color_outLine;
    [SerializeField] float width_outLine;
    private void Awake()
    {
        TMP = transform.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        TMP.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, Dilate);
        TMP.outlineColor = color_outLine;
        TMP.outlineWidth = width_outLine;
        

        TMP.ForceMeshUpdate();
    }
}
