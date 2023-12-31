﻿using Grasshopper.Kernel.Types;

namespace Robots.Grasshopper;

public class GH_Toolpath : GH_Goo<IToolpath>
{
    public GH_Toolpath() { Value = new SimpleToolpath(); }
    public GH_Toolpath(IToolpath native) { Value = native; }
    public override IGH_Goo Duplicate() => new GH_Toolpath(Value);
    public override bool IsValid => true;
    public override string TypeName => "Toolpath";
    public override string TypeDescription => "Toolpath";
    public override string ToString()
    {
        return Value.Targets switch
        {
            IList<Target> targets => $"Toolpath with ({targets.Count} targets)",
            Target target => target.ToString(),
            _ => "Toolpath",
        };
    }

    public override bool CastFrom(object source)
    {
        switch (source)
        {
            case GH_Target target:
                Value = target.Value;
                return true;
            case IToolpath toolpath:
                Value = toolpath;
                return true;
            default:
                return false;
        }
    }

    public override bool CastTo<Q>(ref Q target)
    {
        if (typeof(Q).IsAssignableFrom(typeof(IToolpath)))
        {
            target = (Q)(object)Value;
            return true;
        }

        return false;
    }
}
