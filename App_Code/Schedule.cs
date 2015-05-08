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

    public Schedule(int scheduleID, string day, DateTime start, DateTime end, ClassRoom classRoom, Subject subject)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        this.classRoomID = classRoom.classRoomID;
        this.subjectID = subject.subjectID;
    }

    private Schedule(int scheduleID, string day, DateTime start, DateTime end, int classRoomID, int subjectID)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        this.classRoomID = classRoomID;
        this.subjectID = subjectID;
    }
}