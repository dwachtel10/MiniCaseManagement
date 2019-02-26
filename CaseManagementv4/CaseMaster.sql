CREATE TABLE [dbo].[CaseMaster]
(
	[CaseID] INT IDENTITY (1, 1) Not null,
	CaseNumber INT NOT NULL,
	Agency varchar(50) not null,
	Judge varchar(50) not null,
	FilingDate datetime not null,
	Primary Key Clustered ([CaseID] ASC)
)
