using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
 
[Serializable]
[PostProcess(typeof(PPP_DrunkRenderer), PostProcessEvent.AfterStack, "Custom/PPP_Drunk")]
public sealed class PPP_Drunk : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Drunk Distortion effect intensity.")]
    public FloatParameter amplitude = new FloatParameter { value = 0.5f };

    [Range(0f, 100f), Tooltip("Drunk Distortion effect frequency.")]
    public FloatParameter frequency = new FloatParameter { value = 0.5f };

    [Tooltip("Speed of distorion only x&y used")]
    public Vector4Parameter speed = new Vector4Parameter { value = new Vector4(1, 1, 0, 0)};

    [Tooltip("Size of distorion only x&y used")]
    public Vector4Parameter size = new Vector4Parameter { value = new Vector4(1, 1, 0, 0)};
}
 
public sealed class PPP_DrunkRenderer : PostProcessEffectRenderer<PPP_Drunk>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/PPP_Drunk"));
        sheet.properties.SetFloat("_Amplitude", settings.amplitude);
        sheet.properties.SetFloat("_Frequency", settings.frequency);
        sheet.properties.SetVector("_Speed", settings.speed);
        sheet.properties.SetVector("_Size", settings.size);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}