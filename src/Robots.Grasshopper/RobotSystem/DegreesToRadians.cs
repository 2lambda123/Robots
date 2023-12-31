﻿namespace Robots.Grasshopper;

public class DegreesToRadians : GH_Component
{
    public DegreesToRadians() : base("Degrees to radians", "DegToRad", "Manufacturer dependent degrees to radians conversion.", "Robots", "Utility") { }
    public override GH_Exposure Exposure => GH_Exposure.primary;
    public override Guid ComponentGuid => new("{C10B3A17-5C19-4805-ACCF-839B85C4D21C}");
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconAngles");

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddNumberParameter("Degrees", "D", "Degrees", GH_ParamAccess.list);
        pManager.AddParameter(new RobotSystemParameter(), "Robot system", "R", "Robot system", GH_ParamAccess.item);
        pManager.AddIntegerParameter("Mechanical group", "G", "Mechanical group index", GH_ParamAccess.item, 0);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddParameter(new JointsParameter(), "Radians", "R", "Radians", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        var degrees = new List<double>(6);
        RobotSystem? robotSystem = null;
        int group = 0;

        if (!DA.GetDataList(0, degrees)) return;
        if (!DA.GetData(1, ref robotSystem) || robotSystem is null) return;
        if (!DA.GetData(2, ref group)) return;

        var radians = degrees.Select((x, i) => robotSystem.DegreeToRadian(x, i, group)).ToArray();
        DA.SetData(0, radians);
    }
}
