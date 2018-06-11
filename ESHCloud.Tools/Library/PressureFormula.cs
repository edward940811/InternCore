using ESHCloud.Tools.Enum;
using ESHCloud.Tools.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Tools.Library
{
    public class PressureFactory
    {
        public static IPressureConvert CreatePressureConvert(PressureEnum pressureEnum)
        {
            switch (pressureEnum)
            {
                case PressureEnum.atm:
                    return new AtmConvert();
                case PressureEnum.psi:
                    return new PsiConvert();
                case PressureEnum.mmHg:
                    return new MmHgConvert();
                case PressureEnum.inH2O:
                    return new InH2OConvert();
                default:
                    return null;
            }
        }
    }
    public interface IPressureConvert
    {
        Pressure Convert(decimal value);
    }

    public class AtmConvert : IPressureConvert
    {
        public Pressure Convert(decimal value)
        {
            return new Pressure()
            {
                Atm = value * 1,
                Psi = value * (decimal)14.7,
                MmHg = value * 760,
                InH2O = value * 407
            };
        }
    }

    public class PsiConvert : IPressureConvert
    {
        public Pressure Convert(decimal value)
        {
            return new Pressure()
            {
                Atm = Math.Round(value * 1 / (decimal)14.7, 4, MidpointRounding.AwayFromZero),
                Psi = value * 1,
                MmHg = Math.Round(value * 760 / (decimal)14.7, 4, MidpointRounding.AwayFromZero),
                InH2O = Math.Round(value * 407 / (decimal)14.7, 4, MidpointRounding.AwayFromZero)
            };
        }
    }

    public class MmHgConvert : IPressureConvert
    {
        public Pressure Convert(decimal value)
        {
            return new Pressure()
            {
                Atm = Math.Round(value * 1 / 760, 4, MidpointRounding.AwayFromZero),
                Psi = Math.Round(value * (decimal)14.7 / 760, 4, MidpointRounding.AwayFromZero),
                MmHg = value * 1,
                InH2O = Math.Round(value * 407 / 760, 4, MidpointRounding.AwayFromZero)
            };
        }
    }

    public class InH2OConvert : IPressureConvert
    {
        public Pressure Convert(decimal value)
        {
            return new Pressure()
            {
                Atm = Math.Round(value * 1 / 407, 4, MidpointRounding.AwayFromZero),
                Psi = Math.Round(value * (decimal)14.7 / 407, 4, MidpointRounding.AwayFromZero),
                MmHg = Math.Round(value * 760 / 407, 4, MidpointRounding.AwayFromZero),
                InH2O = value * 1
            };
        }
    }

}
