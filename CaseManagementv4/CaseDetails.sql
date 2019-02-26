CREATE TABLE [dbo].[CaseDetails] (
    [DetailsID]          INT          IDENTITY (1, 1) NOT NULL,
    [CaseID]             INT          NOT NULL,
    [DefendantLastName]  VARCHAR (50) NOT NULL,
    [DefendantFirstName] VARCHAR (50) NOT NULL,
    [DefendantAddress]   VARCHAR (50) NOT NULL,
    [DefendantCity]      VARCHAR (50) NOT NULL,
    [DefendantState]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DetailsID] ASC),
    FOREIGN KEY ([CaseID]) REFERENCES [dbo].[CaseMaster] ([CaseID])
	);