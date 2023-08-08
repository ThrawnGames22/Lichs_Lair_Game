

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PixelizeFeature : ScriptableRendererFeature
{
    //Holds render pass components for when it needs to be applied
    [System.Serializable]
    public class CustomPassSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

        //Calculates pixel resolution of final rendered image
        public int screenHeight = 144;
    }

    [SerializeField] private CustomPassSettings settings;
    private PixelizePass customPass;

    //Overides pass with settings
    public override void Create()
    {
        customPass = new PixelizePass(settings);
    }

    //Adds custom pass to queue of passes to be further executed in each frame
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {

#if UNITY_EDITOR

//Doesn't add it to scene camera
        if (renderingData.cameraData.isSceneViewCamera) return;
#endif
        renderer.EnqueuePass(customPass);
    }
}


