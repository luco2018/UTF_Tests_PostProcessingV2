using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting5Renderer), PostProcessEvent.AfterStack, "Custom/Test/CustomSorting5")]
    public class CustomSorting5 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting5Renderer : PostProcessEffectRenderer<CustomSorting5>
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
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 4);
        }
    }
}