using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Schedule
{
    public int scheduleID;
    public int classRoomID;
    public int subjectID;
    public string day;
    public DateTime start;
    public DateTime end;

    public Schedule()
    {

    }

    public Schedule(int scheduleID, string day, DateTime start, DateTime end, ClassRoom classRomm, Subject subject)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        classRoomID = classRomm.classRoomID;
        subjectID = subject.subjectID;
    }
}