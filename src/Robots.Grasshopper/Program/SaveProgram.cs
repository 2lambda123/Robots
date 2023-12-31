﻿namespace Robots.Grasshopper;

public class SaveProgram : GH_Component
{
    public SaveProgram() : base("Save program", "SaveProg", "Saves a program to a text file.", "Robots", "Components") { }
    public override GH_Exposure Exposure => GH_Exposure.senary;
    public override Guid ComponentGuid => new("{1DE69EAA-AA4C-44F2-8748-F19B041F8F58}");
    protected override System.Drawing.Bitmap Icon => Util.GetIcon("iconSave");

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddParameter(new ProgramParameter(), "Program", "P", "Program", GH_ParamAccess.item);
        pManager.AddTextParameter("Folder", "F", "Folder", GH_ParamAccess.item);
        pManager[1].Optional = true;
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        IProgram? program = null;
        string? folder = null;

        if (!DA.GetData(0, ref program) || program is null) return;
        if (!DA.GetData(1, ref folder) || folder is null) return;

        try
        {
            program.Save(folder);
        }
        catch (Exception e)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Error, $" Program could not be saved: {e.Message}");
        }
    }
}
