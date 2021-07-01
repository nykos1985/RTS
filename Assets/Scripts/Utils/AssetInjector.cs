using System;
using System.Reflection;

namespace Utils
{
    public static class AssetInjector
    {
        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                              BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute(typeof(InjectAssetAttribute)) is InjectAssetAttribute injectAssetAttribute)
                {
                    var prefab = context.GetAsset(injectAssetAttribute.AssetName);
                    field.SetValue(target,prefab);
                }
                
            }
            return target;
        }
    }
}