using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Objects
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Objects Relatives Controller", order = 2000)]
    public class ObjectRelativesControllerAsset : ControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new ObjectRelativesController<object>(arguments);
        }
    }
}
