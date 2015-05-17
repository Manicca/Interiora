using FunctionalityLibrary.Properties;

namespace FunctionalityLibrary.Modes
{
    public class WorkMode
    {
        

        public WorkMode(EnumOfModes mode)
        {
            Mode = mode;
        }

        public EnumOfModes Mode { get; }

        public override string ToString()
        {
            switch (Mode)
            {
                case EnumOfModes.Manual:
                    return Resources.WorkMode_Manual;
                case EnumOfModes.Auto:
                    return Resources.WorkMode_Auto;
                case EnumOfModes.Semi:
                    return Resources.WorkMode_Semi;
                default:
                    return "";
            }
        }
    }
}