/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Merge Into CaseMaster As Target
Using (Values
		(1, 12345, 'Test1', 'TestJudge1', '2019-01-01'),
		(2, 67890, 'Test2', 'TestJudge2', '2019-02-25')
		)
As Source (CaseID, CaseNumber, Agency, Judge, FilingDate)
On Target.CaseID = Source.CaseID
When Not Matched by Target Then
Insert (CaseNumber, Agency, Judge, FilingDate)
Values (CaseNumber, Agency, Judge, FilingDate);

Merge Into CaseDetails As Target
Using (Values
			(1, 1, 'Testy', 'Tester', '1111 1st St.', 'First', 'FirstState'),
			(2, 1, 'Testoo', 'Testdos', '2222 2nd St.', 'Second', 'SecondState'),
			(3, 2, 'Testhree', 'Testres', '3333 3rd St.', 'Third', 'ThirdState')
)
As Source (DetailsID, CaseID, DefendantLastName, DefendantFirstName, DefendantAddress, DefendantCity, DefendantState)
On Target.DetailsID = Source.DetailsID
When Not Matched by Target Then
Insert (CaseID, DefendantLastName, DefendantFirstName, DefendantAddress, DefendantCity, DefendantState)
Values (CaseID, DefendantLastName, DefendantFirstName, DefendantAddress, DefendantCity, DefendantState);

Merge Into Charges As Target
Using (Values
		(1, 1, 'TestCrime1', 'Misdemeanor', 1111.11),
		(2, 1, 'TestCrime2', 'Felony', 2222.22),
		(3, 2, 'TestCrime3', 'Petty', 3333.33),
		(4, 2, 'TestCrime4', 'Misdemeanor', 4444.44),
		(5, 3, 'TestCrime5', 'Felony', 5555.55)
)
As Source (ChargeID, DetailsID, ChargeName, Severity, ORCSection)
On Target.ChargeID = Source.ChargeID
When Not Matched by Target then
Insert (DetailsID, ChargeName, Severity, ORCSection)
Values (DetailsID, ChargeName, Severity, ORCSection);
