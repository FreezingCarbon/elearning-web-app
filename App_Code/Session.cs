using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Session
/// </summary>
public class Session
{
    public int sessionID;
    public int scheduleID;
    public DateTime date;
    public string notesLink;
    public string videoLink;

	public Session()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Session(int sessionID, DateTime date, string notesLink, string videoLink, Schedule schedule)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = schedule.scheduleID;
    }

    private Session(int sessionID, DateTime date, string notesLink, string videoLink, int scheduleID)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = scheduleID;
    }
}