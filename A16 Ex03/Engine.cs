using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    /*    בכלי רכב שעובד על דלק ניתן למצוא את המידע הבא ולהפעיל את הפעולות הבאות:
     סוג הדלק ) Octan98 , Octan96 , Octan95 , Soler )
     כמות הדלק הנוכחית בליטרים ) float )
     כמות הדלק המקסימאלית בליטרים ) float )
     פעולת תדלוק )מתודה שמקבלת כמות ליטרים להוספה וסוג דלק, ומשנה את מצב הדלק
    במידה וסוג הדלק מתאים ואין חריגה מגודל הטנק(
    בכלי רכב חשמלי ניתן למצוא את המידע הבא ולהפעיל את הפעולות הבאות:
     זמן מצבר שנותר בשעות ) float )
     זמן מצבר מקסימאלי בשעות ) float )
     פעולת טעינת מצבר )מתודה שמקבלת נתון שהוא מספר שעות להוסיף למצבר ו"טוענת" את
    המצבר בהתאמה כל עוד מספר השעות לא חורג מהמקסימום(*/
    abstract public class Engine
    {
        protected float m_CurrentEnergyStorageStatus;
        protected float m_MaximumEnergyStorageCapacity;
        public float CurrentEnergyStorageStatus
        {
            get { return m_CurrentEnergyStorageStatus; }
        }
        public float MaximumEnergyStorageCapacity
        {
            get { return m_MaximumEnergyStorageCapacity; }
        }
        public Engine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity)
        {
            m_CurrentEnergyStorageStatus = i_CurrentEnergyStorageStatus;
            m_MaximumEnergyStorageCapacity = i_MaximumEnergyStorageCapacity;
        }
    }
}
