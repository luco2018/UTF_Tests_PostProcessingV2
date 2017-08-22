using System;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(CustomSorting3Renderer), PostProcessEvent.BeforeStack, "Custom/Test/CustomSorting3")]
    public class CustomSorting3 : PostProcessEffectSettings
    {
        
    }

    public class CustomSorting3Renderer : PostProcessEffectRenderer<CustomSorting3>
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
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 2);
        }
    }
}