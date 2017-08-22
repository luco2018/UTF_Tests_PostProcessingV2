using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting4Renderer), PostProcessEvent.BeforeStack, "Custom/Test/CustomSorting4")]
    public class CustomSorting4 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting4Renderer : PostProcessEffectRenderer<CustomSorting4>
    {
        Shader _shader;

        public override void Init()
        {
            if (_shader == null)
                _shader = Shader.Find("Hidden/PostProcessing/Test/CustomSorting");
        }

        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(_shader);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 3);
        }
    }
}