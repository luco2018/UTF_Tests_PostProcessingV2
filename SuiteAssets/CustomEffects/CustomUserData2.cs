using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomUserData2Renderer), PostProcessEvent.AfterStack, "Custom/Test/CustomUserData2")]
    public class CustomUserData2 : PostProcessEffectSettings
    {

    }

    public class CustomUserData2Renderer : PostProcessEffectRenderer<CustomUserData2>
    {
        Shader _shader;

        static class Uniforms
        {
            internal static readonly int _Value = Shader.PropertyToID("_Value");
        }

        public override void Init()
        {
            if (_shader == null)
                _shader = Shader.Find("Hidden/PostProcessing/Test/CustomUserData");
        }

        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(_shader);
            if(context.userData != null)
            {
                object o = 0;
                context.userData.TryGetValue("test", out o);
                float v = (float)o;
                sheet.properties.SetFloat(Uniforms._Value, v);
            }
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 1);
        }
    }
}
