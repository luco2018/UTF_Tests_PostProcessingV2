using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomUserData1Renderer), PostProcessEvent.AfterStack, "Custom/Test/CustomUserData1")]
    public class CustomUserData1 : PostProcessEffectSettings
    {
        [Range(0f, 1f)]public FloatParameter value = new FloatParameter { value = 1 };
    }

    public class CustomUserData1Renderer : PostProcessEffectRenderer<CustomUserData1>
    {
        Shader _shader;

        public override void Init()
        {
            if (_shader == null)
                _shader = Shader.Find("Hidden/PostProcessing/Test/CustomUserData");
        }

        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(_shader);
            context.userData = settings.value.value;
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}
