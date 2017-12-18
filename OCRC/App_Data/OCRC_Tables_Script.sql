CREATE TABLE [dbo].[User] (
    [userID]    INT		IDENTITY (1, 1) NOT NULL,
    [fname]    	VARCHAR (50)  			NOT NULL,
    [lname]    	VARCHAR (50) 			NOT NULL,
    [email]    	VARCHAR (100) 			NOT NULL UNIQUE,
    [password] 	VARCHAR (100) 			NOT NULL,
    [accesslvl] INT 		  		NOT NULL,
    [teamIdentifier] VARCHAR(100) 		NULL,
    [schoolIdentifier]	VARCHAR(100) 		NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

CREATE TABLE [dbo].[Status] (
    [statusID]			INT      IDENTITY (1, 1) NOT NULL,
    [kidIdentifier]		VARCHAR(100)		 NOT NULL UNIQUE,
    [active]           	VARCHAR(100)			 NOT NULL,
    [activityModified] 	DATETIME  			 NOT NULL,
    PRIMARY KEY CLUSTERED ([statusID] ASC)
);

CREATE TABLE [dbo].[Notes] (
    [notesID]      INT		IDENTITY (1, 1) NOT NULL,
    [dateCreated]  DATETIME      			NOT NULL,
    [dateModified] DATETIME      			NOT NULL,
    [statusID]     INT           			NOT NULL,
    [userID] 	   INT 			 		NOT NULL,
    [notes]        VARCHAR(100) 			NULL,
    PRIMARY KEY CLUSTERED ([notesID] ASC),
	CONSTRAINT notesSurKey UNIQUE (dateCreated,userID,statusID)
);

CREATE TABLE [dbo].[Ranking] (
    [rankingID]    INT		IDENTITY (1, 1) NOT NULL,
    [statusID]     INT      		 	NOT NULL,
    [userID] 	   INT 				NOT NULL,
    [dateCreated]  DATETIME 		 	NOT NULL,
    [rank]         INT      		 	NULL,
    [sportType]    VARCHAR(100)      		NOT NULL,
    PRIMARY KEY CLUSTERED ([rankingID] ASC),
	CONSTRAINT rankSurKey UNIQUE (statusID,userID,dateCreated,sportType)
);

CREATE TABLE [dbo].[PasswordReset] (
	[passwordresetID]	INT		IDENTITY (1, 1)	NOT NULL,
	[token]				VARCHAR(100)		NULL,
	[email]				VARCHAR(100) 		NOT NULL UNIQUE,
	PRIMARY KEY CLUSTERED ([passwordresetID] ASC)
);
