CREATE TABLE [dbo].[Charges] (
    [ChargeID]   INT          IDENTITY (1, 1) NOT NULL,
    [DetailsID]     INT        NOT  NULL,
    [ChargeName] VARCHAR (50) NOT NULL,
    [Severity]   VARCHAR (50) NOT NULL,
    [ORCSection] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([ChargeID] ASC),
    FOREIGN KEY ([DetailsID]) REFERENCES [dbo].[CaseDetails] ([DetailsID])
);