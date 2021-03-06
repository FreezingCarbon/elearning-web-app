USE [ELearning_ERP]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[levelID] [numeric](18, 0) NOT NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Level]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Level](
	[name] [varchar](250) NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Message]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[senderID] [numeric](18, 0) NOT NULL,
	[subject] [varchar](128) NOT NULL,
	[body] [varchar](max) NOT NULL,
	[time] [datetime] NOT NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recieve]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recieve](
	[recipientID] [numeric](18, 0) NOT NULL,
	[messageID] [numeric](18, 0) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule](
	[classID] [numeric](18, 0) NOT NULL,
	[subjectID] [numeric](18, 0) NOT NULL,
	[sessionDay] [varchar](20) NOT NULL,
	[startTime] [time](7) NOT NULL,
	[endTime] [time](7) NOT NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Session]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Session](
	[scheduleID] [numeric](18, 0) NOT NULL,
	[date] [date] NOT NULL,
	[videoLink] [varchar](max) NULL,
	[notesLink] [varchar](max) NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[levelID] [numeric](18, 0) NOT NULL,
	[title] [varchar](128) NOT NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teaches]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teaches](
	[teacherID] [numeric](18, 0) NOT NULL,
	[subjectID] [numeric](18, 0) NOT NULL,
	[classID] [numeric](18, 0) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 5/16/2015 9:32:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[username] [varchar](128) NOT NULL,
	[password] [varchar](128) NOT NULL,
	[name] [varchar](128) NOT NULL,
	[mail] [varchar](128) NOT NULL,
	[lastSeen] [date] NULL,
	[userType] [varchar](128) NOT NULL,
	[isAdmin] [bit] NOT NULL CONSTRAINT [DF_User_isAdmin]  DEFAULT ((0)),
	[classID] [numeric](18, 0) NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_main_User] UNIQUE NONCLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [fkClass_level] FOREIGN KEY([levelID])
REFERENCES [dbo].[Level] ([id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [fkClass_level]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([senderID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[Recieve]  WITH CHECK ADD  CONSTRAINT [FK_Recieve_Message] FOREIGN KEY([messageID])
REFERENCES [dbo].[Message] ([id])
GO
ALTER TABLE [dbo].[Recieve] CHECK CONSTRAINT [FK_Recieve_Message]
GO
ALTER TABLE [dbo].[Recieve]  WITH CHECK ADD  CONSTRAINT [FK_Recieve_User] FOREIGN KEY([recipientID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Recieve] CHECK CONSTRAINT [FK_Recieve_User]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Class] FOREIGN KEY([classID])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Class]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Subject] FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Subject]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Schedule] FOREIGN KEY([scheduleID])
REFERENCES [dbo].[Schedule] ([id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Schedule]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Level] FOREIGN KEY([levelID])
REFERENCES [dbo].[Level] ([id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Level]
GO
ALTER TABLE [dbo].[Teaches]  WITH CHECK ADD  CONSTRAINT [FK_Teaches_Class] FOREIGN KEY([classID])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Teaches] CHECK CONSTRAINT [FK_Teaches_Class]
GO
ALTER TABLE [dbo].[Teaches]  WITH CHECK ADD  CONSTRAINT [FK_Teaches_Subject] FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Teaches] CHECK CONSTRAINT [FK_Teaches_Subject]
GO
ALTER TABLE [dbo].[Teaches]  WITH CHECK ADD  CONSTRAINT [FK_Teaches_User] FOREIGN KEY([teacherID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Teaches] CHECK CONSTRAINT [FK_Teaches_User]
GO
