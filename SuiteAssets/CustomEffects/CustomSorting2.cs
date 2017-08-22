using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting2Renderer), PostProcessEvent.BeforeTransparent, "Custom/Test/CustomSorting2")]
    public class CustomSorting2 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting2Renderer : PostProcessEffectRenderer<CustomSorting2>
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
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 1);
        }
    }
}