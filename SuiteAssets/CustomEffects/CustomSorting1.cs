using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting1Renderer), PostProcessEvent.BeforeTransparent, "Custom/Test/CustomSorting1")]
    public class CustomSorting1 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting1Renderer : PostProcessEffectRenderer<CustomSorting1>
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
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}