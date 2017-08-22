using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting6Renderer), PostProcessEvent.AfterStack, "Custom/Test/CustomSorting6")]
    public class CustomSorting6 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting6Renderer : PostProcessEffectRenderer<CustomSorting6>
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
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 5);
        }
    }
}