using System.Collections.Generic;
using Collider2DOptimization;
using UnityEngine;

namespace lib.ndk.Extension
{
    public static class PolygonColliderExtension
    {
        public static void Optimize(this PolygonCollider2D col, float tolerance = 0.1f)
        {
            var originalPaths = new List<List<Vector2>>();


            for (int i = 0; i < col.pathCount; i++)
            {
                List<Vector2> path = new List<Vector2>(col.GetPath(i));
                originalPaths.Add(path);
            }

            //Reset the original paths
            if (tolerance <= 0)
            {
                for (int i = 0; i < originalPaths.Count; i++)
                {
                    List<Vector2> path = originalPaths[i];
                    col.SetPath(i, path.ToArray());
                }

                return;
            }

            for (int i = 0; i < originalPaths.Count; i++)
            {
                List<Vector2> path = originalPaths[i];
                path = ShapeOptimizationHelper.DouglasPeuckerReduction(path, tolerance);
                col.SetPath(i, path.ToArray());
            }
        }
    }
}