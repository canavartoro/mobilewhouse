using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Enums
{
    public enum ControlReason
    {
        ÜretimBaşlangıcı = 1,
        ÜretimAraKontrol = 2,
        SonParçaKontrol = 3
    }

    public enum ControlType
    {
        SıkıKontrol = 1,
        NormalKontrol = 2,
        GevşekKontrol = 3
    }

    public enum ActionState
    {
        Açık = 1,
        Kapalı = 2
    }
}
