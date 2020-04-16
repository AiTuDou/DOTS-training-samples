﻿﻿using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FireVisualSystem : SystemBase
{
    protected override void OnUpdate()
    {
        
        var ecb = new EntityCommandBuffer(Allocator.Temp);
        
        Entities.WithAll<Fire>().
            ForEach((ref FireMaterialComponent mat,  ref Translation translation, in ValueComponent val) =>
        {
            translation.Value.y = val.Value / 255f;
            mat.Amount = val.Value / 255f;
            // ecb.SetComponent(e, new FireMaterialComponent { Amount = val.Value / 255f });

        }).Run();

        ecb.Playback(EntityManager);
    }
}