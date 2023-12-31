﻿namespace Robots.Grasshopper;

public class ProgramParameter : GH_Param<GH_Program>
{
    public ProgramParameter() : base("Program parameter", "Program", "This is a robot program", "Robots", "Parameters", GH_ParamAccess.item) { }
    public override GH_Exposure Exposure => GH_Exposure.quarternary;
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconProgramParam");
    public override Guid ComponentGuid => new("{9C4F1BB6-5FA2-44DA-B7EA-421AF31DA054}");
    protected override GH_Program PreferredCast(object data) =>
        data is IProgram cast ? new GH_Program(cast) : null!;
}